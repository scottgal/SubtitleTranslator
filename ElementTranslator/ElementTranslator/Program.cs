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

        translateConfig = SetupConfig(translateConfig);
        var whisperHttpClient = new HttpClient()
            { BaseAddress = new Uri(translateConfig.WhisperAIUrl), Timeout = TimeSpan.FromMinutes(30) };

        var whisperAIService = new WhisperTenscriptionService(whisperHttpClient, translateConfig);
        var mp3Result = await whisperAIService.ExtractAudioFromVideoFile(translateConfig.SourceVideoFilePath, translateConfig.DestinationPath);
        await whisperAIService.TranscribeVideoFile(mp3Result.filePath, translateConfig.DestinationPath);
        return;
        AnsiConsole.MarkupLine("[bold]Current directory[/]: [green]{0}[/]", Directory.GetCurrentDirectory());
   

        // AnsiConsole.MarkupLine("[bold]Config File directory[/]: [green]{0}[/]", File.Exists("translate.json"));

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
            AnsiConsole.MarkupLine("[orange1 bold]Had to transform the source video path as it wasn't an absolute path.[/]", sourceFile);
        }

        translateConfig.DestinationPath =  destinationPath;
        if (Path.HasExtension(translateConfig.DestinationPath))
        {
            AnsiConsole.MarkupLine("[red bold]Destination path is not a directory[/]", destinationPath);
            Environment.Exit(-1);
        }
        translateConfig.Mp3Path = ReplacePath(mp3Path);
        translateConfig.SubtitleFilePath = ReplacePath(subtitleFile);
        
        
       
        string ReplacePath(string path)
        {
            path =  path.Replace("{*}",  Path.Combine(destinationPath, Path.GetFileNameWithoutExtension(sourceFile)));
            return path;
        }
      
        

        return translateConfig;
    }
}