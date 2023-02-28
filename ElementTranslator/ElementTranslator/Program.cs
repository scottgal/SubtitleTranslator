using System.Text.RegularExpressions;
using Xabe.FFmpeg.Downloader;

internal class Program
{
    private static JsonSerializerOptions _jsonSerializerOptions = new JsonSerializerOptions()
    {
        TypeInfoResolver = TranslatorJsonContext.Default,
        AllowTrailingCommas = true,
        ReadCommentHandling = JsonCommentHandling.Skip
    };

    private static async Task Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;
        await FFmpegDownloader.GetLatestVersion(FFmpegVersion.Official);

        var translateConfig = JsonSerializer.Deserialize<TranslateConfig>(
            await File.ReadAllTextAsync(Path.Combine(Directory.GetCurrentDirectory(), "translate.json")),
            _jsonSerializerOptions);

        if(translateConfig is null)
        {
            AnsiConsole.MarkupLine("[red]Failed to load translate.json[/]");
            Environment.Exit(-1);
        }  
        translateConfig = SetupConfig(translateConfig);
        var whisperAIService = new WhisperTenscriptionService(translateConfig);



        if (translateConfig.Mode.HasFlag(Mode.Extract))
        {
            var mp3Result = await whisperAIService.ExtractAudioFromVideoFile(translateConfig.SourceVideoFilePath,
                translateConfig.Mp3Path);
            if (!mp3Result.success)
            {
                AnsiConsole.MarkupLine("[red]Failed to extract audio from video file[/]");
                Environment.Exit(-1);
            }
        }
        else
        {
            if (!File.Exists(translateConfig.Mp3Path))
            {
                AnsiConsole.MarkupLine("[red]Mp3 file not found[/]");
                Environment.Exit(-1);
            }
        }

        if (translateConfig.Mode.HasFlag(Mode.Transcribe) && !File.Exists(translateConfig.SubtitleFilePath))
        {
            var whisperHttpClient = new HttpClient()
                { BaseAddress = new Uri(translateConfig.WhisperAIUrl), Timeout = TimeSpan.FromMinutes(120) };

           var result = await whisperAIService.TranscribeVideoFile(whisperHttpClient, translateConfig.Mp3Path, translateConfig.SubtitleFilePath);
           if (!result)
           {
               AnsiConsole.MarkupLine($"[red]Failed to transcribe file.[/] {translateConfig.Mp3Path}");
               Environment.Exit(-1);
           }
        }
        else
        {
            if (!File.Exists(translateConfig.SubtitleFilePath))
            {
                AnsiConsole.MarkupLine("[red]Subtitle file not found[/]");
                Environment.Exit(-1);
            }
        }

        AnsiConsole.MarkupLine("[bold]Current directory[/]: [green]{0}[/]", Directory.GetCurrentDirectory());


        if (!translateConfig.Mode.HasFlag(Mode.Translate))
        {
            AnsiConsole.MarkupLine("[bold]Translate mode not enabled[/]");
            Environment.Exit(0);
        }

        if (!File.Exists(translateConfig.SubtitleFilePath))
        {
            AnsiConsole.MarkupLine("[red]Subtitle file not found[/]");
            Environment.Exit(-1);
        }

        var httpClient = new HttpClient(new HttpRetryMessageHandler(new HttpClientHandler()))
            { BaseAddress = new Uri(translateConfig.LibreTranslateUrl), Timeout = TimeSpan.FromSeconds(30) };

        var sourceFile = translateConfig.SubtitleFilePath;

        var parser = new SrtParser();
        await using var fileStream = File.OpenRead(sourceFile);
        var items = parser.ParseStream(fileStream, Encoding.UTF8);

        var libreTranslateService = new LibreTranslateService();
        var langList = await libreTranslateService.GetSupportedLanguagesAsync(httpClient);
        var subTitleTranslateService = new SubtitleTranslatorService(libreTranslateService, translateConfig);
        await subTitleTranslateService.TranslateLanguage(langList, items, httpClient);


        AnsiConsole.MarkupLine("[green bold]Finished translating[/]");
        Debug.WriteLine("Languages: " + langList.Count);


        Debug.WriteLine("FINISHED");
        Console.ReadLine();
    }

    static TranslateConfig SetupConfig(TranslateConfig translateConfig)
    {
        var sourceFile = translateConfig.SourceVideoFilePath;
        var subtitleFile = translateConfig.SubtitleFilePath;
        var destinationPath = translateConfig.DestinationPath;
        var mp3Path = translateConfig.Mp3Path;
        if (!File.Exists(sourceFile))
        {
            AnsiConsole.MarkupLine("[red bold]Source file not found[/]", sourceFile);
            Environment.Exit(-1);
        }

        if (!sourceFile.IsFullPath())
        {
            sourceFile = Path.Combine(Directory.GetCurrentDirectory(), sourceFile);
            AnsiConsole.MarkupLine(
                "[orange1 bold]Had to transform the source video path as it wasn't an absolute path.[/]", sourceFile);
        }

        if (Path.HasExtension(destinationPath))
        {
            AnsiConsole.MarkupLine("[red bold]Destination path is not a directory[/]", destinationPath);
            Environment.Exit(-1);
        }

        if (!destinationPath.IsFullPath())
        {
            destinationPath = Path.Combine(Path.GetDirectoryName(sourceFile), Regex.Unescape(destinationPath));
        }

        translateConfig.DestinationPath = destinationPath;

        translateConfig.Mp3Path = ReplacePath(mp3Path);
        translateConfig.SubtitleFilePath = ReplacePath(subtitleFile);


        string ReplacePath(string path)
        {
            path = path.Replace("{*}", Path.Combine(destinationPath, Path.GetFileNameWithoutExtension(sourceFile)));
            return path;
        }


        return translateConfig;
    }
}