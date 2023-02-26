internal class Program
{
    private static async Task Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;

        AnsiConsole.MarkupLine("[bold]Current directory[/]: [green]{0}[/]", Directory.GetCurrentDirectory());
        var translateConfig = JsonSerializer.Deserialize(
            await File.ReadAllTextAsync(Path.Combine(Directory.GetCurrentDirectory(), "translate.json")),
            TranslatorJsonContext.Default.TranslateConfig);

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
}

/*
 * using Spectre.Console;
using System;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

var client = new HttpClient();

// Progress
await AnsiConsole.Progress()
    .Columns(new ProgressColumn[]
    {
        new TaskDescriptionColumn(),
        new ProgressBarColumn(),
        new PercentageColumn(),
        new RemainingTimeColumn(),
        new SpinnerColumn(),
    })
    .StartAsync(async ctx =>
    {
        await Task.WhenAll(items.Select(async item =>
        {
            var task = ctx.AddTask(item.name, new ProgressTaskSettings
            {
                AutoStart = false
            });

            await Download(client, task, item.url);
        }));
    });

// This methods downloads a file and updates progress
async Task Download(HttpClient client, ProgressTask task, string url)
{
    try
    {
        using (HttpResponseMessage response = await client.GetAsync(url, HttpCompletionOption.ResponseHeadersRead))
        {
            response.EnsureSuccessStatusCode();

            // Set the max value of the progress task to the number of bytes
            task.MaxValue(response.Content.Headers.ContentLength ?? 0);
            // Start the progress task
            task.StartTask();

            var filename = url.Substring(url.LastIndexOf('/') + 1);
            AnsiConsole.MarkupLine($"Starting download of [u]{filename}[/] ({task.MaxValue} bytes)");

            using (var contentStream = await response.Content.ReadAsStreamAsync())
            using (var fileStream = new FileStream(filename, FileMode.Create, FileAccess.Write, FileShare.None, 8192, true))
            {
                var buffer = new byte[8192];
                while (true)
                {
                    var read = await contentStream.ReadAsync(buffer, 0, buffer.Length);
                    if (read == 0)
                    {
                        AnsiConsole.MarkupLine($"Download of [u]{filename}[/] [green]completed![/]");
                        break;
                    }

                    // Increment the number of read bytes for the progress task
                    task.Increment(read);

                    // Write the read bytes to the output stream
                    await fileStream.WriteAsync(buffer, 0, read);
                }
            }
        }
    }
    catch (Exception ex)
    {
        // An error occured
        AnsiConsole.MarkupLine($"[red]Error:[/] {ex}");
    }
}

 */