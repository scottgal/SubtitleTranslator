using Microsoft.AspNetCore.WebUtilities;
using Xabe.FFmpeg;

namespace ElementTranslator;

public class WhisperTenscriptionService
{
    private TranslateConfig _config;
    private HttpClient _whisperHttpClient;
    public WhisperTenscriptionService(TranslateConfig config)
    {
        
        _config = config;
        sw.Start();
    }

    private Stopwatch sw = new();


    public async Task<WhisperDetectLanguage> DetectLanguage(HttpClient whisperHttpClient, string mp3FilePath)
    {
        var startTimestamp = sw.ElapsedMilliseconds;
        var outStr = new WhisperDetectLanguage();
        await AnsiConsole.Status()
            .AutoRefresh(true)
            .Spinner(Spinner.Known.Default)
            .StartAsync("[yellow]Beginning subtitle for file[/]" + Path.GetFileName(mp3FilePath), async ctx =>
            {
                ctx.Status($"Beginning Subtitle Transcription for file, this will take a few minutes. {mp3FilePath}");
                ctx.Refresh();
                  
                await using var stream = System.IO.File.OpenRead(mp3FilePath);
  
                using var request = new HttpRequestMessage(HttpMethod.Post,  "detect-language");
                using var content = new MultipartFormDataContent
                {
                      
                    { new StreamContent(stream), "audio_file", Path.GetFileName(mp3FilePath) }
                };
                request.Content = content;
                try
                {
                     var resp=  await whisperHttpClient.SendAsync(request);

                     if (!resp.IsSuccessStatusCode)
                     {
                         AnsiConsole.MarkupLine($"[red]Error[/] [white bold] {resp.StatusCode}[/] [red] for file.[/] {mp3FilePath}");
                         return;
                     }
                     outStr =JsonSerializer.Deserialize(await resp.Content.ReadAsStringAsync(), TranslatorJsonContext.Default.WhisperDetectLanguage);
                     var elapsed = sw.ElapsedMilliseconds - startTimestamp;
                    AnsiConsole.MarkupLine($"[green]Detected  language[/] [white bold] {outStr}[/][green] for file in {TimeSpan.FromMilliseconds(elapsed).TotalMinutes} minutes.[/] {mp3FilePath}");
                }
                catch (Exception)
                {
          
                    //TODO: LOGGING.
             
                }

                
            });
        return outStr;
    }
    
    public async Task<bool> TranscribeVideoFile(HttpClient whisperHttpClient, TranslateConfig config)
    {
        var startTimestamp = sw.ElapsedMilliseconds;
        string output = "";
        await AnsiConsole.Status()
                .AutoRefresh(true)
                .Spinner(Spinner.Known.Default)
                .StartAsync("[yellow]Beginning subtitle for file[/]" + Path.GetFileName(config.Mp3Path),async ctx =>
                {
                  
                        ctx.Status($"Beginning Subtitle Transcription for file, this will take a few minutes. {config.Mp3Path}");
                        ctx.Refresh();
                  
                        await using var stream = File.OpenRead(config.Mp3Path);
                        var queryParams = new Dictionary<string, string>
                        {
                            { "task", "transcribe" },
                            {"language", config.SourceLanguage  },
                            { "output", "srt" },
                        };
                        var queryString = QueryHelpers.AddQueryString("asr", queryParams);
                      
                        using var request = new HttpRequestMessage(HttpMethod.Post,  queryString);
                        using var content = new MultipartFormDataContent
                        {
                      
                            { new StreamContent(stream), "audio_file", Path.GetFileName(config.Mp3Path) }
                        };

                        request.Content = content;

                        try
                        {
                            var response=  await whisperHttpClient.SendAsync(request);
                            string output = config.DestinationPath;
                            await File.WriteAllBytesAsync(output, await response.Content.ReadAsByteArrayAsync());
                            var elapsed = sw.ElapsedMilliseconds - startTimestamp;
                            AnsiConsole.MarkupLine($"[green]Cpmpleted Subtitle Transcription for file in {TimeSpan.FromMilliseconds(elapsed).TotalMinutes} minutes.[/] {config.Mp3Path}"); 

                        }
                        catch (Exception)
                        {
          
   //TODO: LOGGING.
                            return false;
                        }
                     
                     return true;

                });



        //If we get here smell a rat.
        return false;

    }
    public  async Task<(bool success, string filePath)> ExtractAudioFromVideoFile( string videoFilePath, string mp3FilePath)
    {
        var startTimestamp = sw.ElapsedMilliseconds;
     
        if(File.Exists(mp3FilePath)) return (true, mp3FilePath);
        
        await AnsiConsole.Status()
                .AutoRefresh(true)
                .Spinner(Spinner.Known.Dots)
                .StartAsync("[yellow]Beginning mp3 extraction for file[/]" + Path.GetFileName(videoFilePath),async ctx =>
                {
               
                    var conversion =await FFmpeg.Conversions.FromSnippet.ExtractAudio( videoFilePath, mp3FilePath);
                    conversion.SetOverwriteOutput(true);
                    conversion.UseMultiThread(Environment.ProcessorCount);

                    conversion.SetOutputFormat(Format.mp3);
                    ctx.Status("[green]Starting conversion[/]");
                    conversion.OnProgress +=  (sender, args) =>
                    {
                        ctx.Status($"{args.Duration}/{args.TotalLength}   {Math.Round((double)args.Percent)}% {videoFilePath}");
                    };
                    await conversion.Start();
                  
                });

        AnsiConsole.MarkupLine($"[green]Cpmpleted MP3 extraction for file.[/] {videoFilePath} It took" +
                               $" {TimeSpan.FromMilliseconds(sw.ElapsedMilliseconds - startTimestamp).TotalSeconds} seconds"); 
     
            return (true, mp3FilePath);

        }
    
}