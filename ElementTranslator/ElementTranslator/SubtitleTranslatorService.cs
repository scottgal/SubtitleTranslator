using System.Collections.Concurrent;
using FastDeepCloner;
using SubtitlesParser.Classes;
using SubtitlesParser.Classes.Writers;

namespace ElementTranslator;

public class SubtitleTranslatorService
{
    private readonly TranslateConfig _config;
    private readonly LibreTranslateService _libreTranslateService;

    public SubtitleTranslatorService(LibreTranslateService libreTranslateService, TranslateConfig translateConfig)
    {
        _libreTranslateService = libreTranslateService;
        _config = translateConfig;
    }


    private string GetOutputFileName(string languageCode)
    {
        var sourceFile = _config.SubtitleFilePath;
        var sourceLanguage = _config.SourceLanguage;

        var fileName = Path.GetFileNameWithoutExtension(sourceFile);
        if (fileName.EndsWith($".{sourceLanguage}")) fileName = fileName.Substring(0, fileName.Length - 3);
        var destDir = _config.DestinationPath;
        if (string.IsNullOrEmpty(destDir))
        {
            destDir = Path.GetDirectoryName(sourceFile);
        }
        else
        {
            if (!Directory.Exists(destDir)) Directory.CreateDirectory(destDir);
        }

        var outfileName = $"{fileName}.{languageCode}.srt";

        return Path.Combine(destDir, outfileName);
    }

    private ProgressTask _totalTask;
    public async Task TranslateLanguage(List<Languages> langList, List<SubtitleItem> items,
        HttpClient httpClient)
    {
        var paralelOptions2 = new ParallelOptions { MaxDegreeOfParallelism = 8 };

        var execList = new List<Languages>();
        foreach (var lang in langList)
        {
            if (!_config.Languages.Contains(lang.code)) continue;
            if (!File.Exists(GetOutputFileName(lang.code))) execList.Add(lang);
        }

        var lineCount = items.Sum(x => x.PlaintextLines.Count);
        execList = execList.OrderBy(x => x.name).ToList();
        AnsiConsole.MarkupLine("[bold]Translating file[/]: [green]{0}[/]", _config.SubtitleFilePath);
        AnsiConsole.MarkupLine("[bold]Translating to[/]: [aqua]{0} languages[/]", execList.Count);
        // Progress
        await AnsiConsole.Progress()
            .Columns(new TaskDescriptionColumn(), new ProgressBarColumn(), new PercentageColumn(),
                new RemainingTimeColumn(), new SpinnerColumn(Spinner.Known.Dots2))
            .AutoRefresh(true) // Turn off auto refresh
            .AutoClear(true) // Do not remove the task list when done
            .HideCompleted(true)
            .StartAsync(async ctx =>
            {
              _totalTask=  ctx.AddTask("[bold red]Total:[/]", new ProgressTaskSettings
                {
                    MaxValue = lineCount * execList.Count,
                    AutoStart = true
                });
                
                await Parallel.ForEachAsync(execList, paralelOptions2, async (item, t) =>
                {
                    var task = ctx.AddTask(item.name, new ProgressTaskSettings
                    {
                        MaxValue = lineCount,
                        AutoStart = false
                    });

                    await TranslateLanguage(httpClient, GetOutputFileName(item.code), item, items, task);
                });
            });
    }


    public async Task TranslateLanguage(HttpClient httpClient,  string sourceFile,
        Languages languageCode, List<SubtitleItem> items, ProgressTask task)
    {
        var rnd = new Random();

        task.StartTask();
        var outItems = new ConcurrentBag<SubtitleItem?>();
        var languageDictionary = new ConcurrentDictionary<string, string>();
        await Parallel.ForEachAsync(items, new ParallelOptions { MaxDegreeOfParallelism = 4 },
            async (item, t) =>
            {
                var newItem = item.Clone();
                for (var index = 0; index < item.PlaintextLines.Count; index++)
                {
                    var plainLine = item.PlaintextLines[index];
                    var translated =
                        await _libreTranslateService.TranslateAsync( httpClient ,
                            plainLine, "en", languageCode.code, languageDictionary);
                    newItem.PlaintextLines[index] = translated;
                    newItem.Lines[index] = translated;
                    task.Increment(1);
                    _totalTask.Increment(1);
                    Debug.WriteLine(item.StartTime + " :: " + languageCode.name + " :: " + plainLine + " :: " +
                                    translated);
                }

                outItems.Add(newItem);
            });
        var writer = new SrtWriter();
        var outList = outItems.OrderBy(x => x.StartTime).ToList();

        await using var fileStream = File.OpenWrite(GetOutputFileName(languageCode.code));
        await writer.WriteStreamAsync(fileStream, outList);
    }
}