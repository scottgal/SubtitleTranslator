using System.Collections.Concurrent;
using FastDeepCloner;
using SubtitlesParser.Classes;
using SubtitlesParser.Classes.Writers;

namespace ElementTranslator;

public class SubtitleTranslatorService
{
    private readonly TranslateConfig _config;
    private readonly LibreTranslateService _libreTranslateService;

    private ParallelOptions _languageParalellOptions =
        new ParallelOptions { MaxDegreeOfParallelism = Environment.ProcessorCount};

    private  ParallelOptions _lineParalellOptions;
    public SubtitleTranslatorService(LibreTranslateService libreTranslateService, TranslateConfig translateConfig)
    {
        _libreTranslateService = libreTranslateService;
        _config = translateConfig;
        _lineParalellOptions =
            new ParallelOptions { MaxDegreeOfParallelism = Environment.ProcessorCount / _languageParalellOptions.MaxDegreeOfParallelism };
    }
    


    private string GetOutputFileName(string languageCode, bool isTemp = false)
    {
        var sourceFile = _config.SubtitleFilePath;
        var sourceLanguage = _config.SourceLanguage;

        var fileName = Path.GetFileNameWithoutExtension(sourceFile);
        if (fileName.EndsWith($".{sourceLanguage}")) fileName = fileName.Substring(0, fileName.Length - 3);
        var destDir = _config.DestinationPath;
        if (string.IsNullOrEmpty(destDir))
            destDir = Path.GetDirectoryName(sourceFile);
        
        if (!Directory.Exists(destDir)) Directory.CreateDirectory(destDir);

        var outfileName = $"{fileName}.{languageCode}.srt";
        if(isTemp) outfileName = $"{fileName}.{languageCode}.srt.tmp";
        return Path.Combine(destDir, outfileName);
    }

    private int MaxLangName = 0;
    
    private int ExecutorCount = 0;
    private ProgressTask _totalTask;
    public async Task TranslateLanguage(List<Languages> langList, List<SubtitleItem> items,
        HttpClient httpClient)
    {


        var execList = new List<Languages>();
        
        foreach (var lang in langList)
        {
            if (MaxLangName < lang.name.Length) MaxLangName = lang.name.Length;
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
              _totalTask=  ctx.AddTask("[bold red]Total:[/]".PadRight(40), new ProgressTaskSettings
                {
                    MaxValue = lineCount * execList.Count,
                    AutoStart = true
                });
                
                await Parallel.ForEachAsync(execList, _languageParalellOptions, async (item, t) =>
                {
                    var task = ctx.AddTask(TaskDescription(null, isInitial:true, description:item.name ) , new ProgressTaskSettings
                    {
                        MaxValue = lineCount,
                        AutoStart = false
                    });

                    ExecutorCount++;
                    await TranslateLanguage(httpClient, GetOutputFileName(item.code), item, items, task);
                    ExecutorCount--;
                });
            });
    }

    private const int retries = 3;

    public async Task TranslateLanguage(HttpClient httpClient,  string sourceFile,
        Languages languageCode, List<SubtitleItem> items, ProgressTask task)
    {
        var rnd = new Random();

        task.StartTask();
        var tempItem =await LoadTempFile(languageCode);
        task.Increment(tempItem.Count);
        _totalTask.Increment(tempItem.Count);
        var procItems = items.Where(x => tempItem.All(itm => itm.StartTime != x.StartTime));
        
        var outItems = new ConcurrentBag<SubtitleItem?>(tempItem);

        _lineParalellOptions.MaxDegreeOfParallelism =(int) Math.Ceiling((double)Environment.ProcessorCount / ExecutorCount);
        var languageDictionary = new ConcurrentDictionary<string, string>();
        await Parallel.ForEachAsync(procItems, _lineParalellOptions,
            async (item, t) =>
            {
                var newItem = item.Clone();
                for (var index = 0; index < item.PlaintextLines.Count; index++)
                {
                    var plainLine = item.PlaintextLines[index];
                    (bool success, string response) translated = new();
                    if (languageDictionary.ContainsKey(plainLine)) translated = (true, languageDictionary[plainLine]);
                    else
                    {
                        for (var i = 0; i < retries; i++)
                        {
                            try
                            {
                                translated =
                                    await _libreTranslateService.TranslateAsync( httpClient ,
                                        plainLine, _config.SourceLanguage, languageCode.code, languageDictionary);
                                if (translated.Item1) break;
                            }
                            catch (Exception e)
                            {
                                AnsiConsole.WriteException(e);
                                await Task.Delay(rnd.Next(1000, 5000));
                                //TODO: What to do here.
                                translated = (true, plainLine);
                            }
                        }
                    }
                    
                    newItem.PlaintextLines[index] = translated.response;
                    newItem.Lines[index] = translated.response;
                   
                    Debug.WriteLine(item.StartTime + " :: " + languageCode.name + " :: " + plainLine + " :: " +
                                    translated.response);
                }

                lock (task)
                {
                    task.Increment(1);
                    var percent = (int) (task.Value * 100 / task.MaxValue);

                    _totalTask.Description = TaskDescription(_totalTask, isTitle: true, description: "Total");
                    task.Description = TaskDescription(task, description: languageCode.name);
                }
                    
              lock(_totalTask)
                    _totalTask.Increment(1);
                 
                
                if (task.Value % 100 == 0)
                {
                  
                    await WriteTempFile(languageCode, outItems);
                }
                outItems.Add(newItem);
            });
        await WriteTempFile(languageCode, outItems);
        File.Move(GetOutputFileName(languageCode.code, true), GetOutputFileName(languageCode.code, false));
    }

    private string TaskDescription(ProgressTask? task, string description, bool isTitle = false, double maxValue =0, bool isInitial =false)
    {
        var count = 0d;
        var max = maxValue;
        var speed = 0d;
        if(!isInitial && task is not null)
        {
            count = task.Value;
            max = task.MaxValue;
            speed = Math.Round(task.Speed.Value,3);
        }

        var rowStyle = new Style().Decoration(Decoration.Bold).Foreground(isTitle ? Color.Red  :isInitial ? Color.Orange1 : Color.Green).ToMarkup();
        var desDisplau = $"[{rowStyle}]{description.PadRight(15)}[/]";
        
        var taskCount = $"{count}/{max}".PadRight(12);

        var speedDisplay = $"({speed}/s)".PadLeft(15);
        
      

        return $"{desDisplau} {taskCount} {speedDisplay}";
    }


    private async Task<List<SubtitleItem>> LoadTempFile(Languages languageCode)
    {
        var fileName = GetOutputFileName(languageCode.code, true);
        if (!File.Exists(fileName)) return new List<SubtitleItem>();
        AnsiConsole.WriteLine("Loaded Temp File: " + fileName);
        var parser = new SrtParser();
        await using var fileStream = File.OpenRead(fileName);
        var items = parser.ParseStream(fileStream, Encoding.UTF8);
        return items;
    }
    private async Task WriteTempFile(Languages languageCode, ConcurrentBag<SubtitleItem?> outItems)
    {
        var writer = new SrtWriter();
       var outList = outItems.OrderBy(x => x.StartTime).ToList();
        await using var fileStream = File.Create(GetOutputFileName(languageCode.code, true));
        await writer.WriteStreamAsync(fileStream, outList);
    }
}