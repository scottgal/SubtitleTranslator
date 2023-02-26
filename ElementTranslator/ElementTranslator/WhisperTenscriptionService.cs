using Xabe.FFmpeg;

namespace ElementTranslator;

public class WhisperTenscriptionService
{
    private TranslateConfig _config;
    private HttpClient _whisperHttpClient;
    public WhisperTenscriptionService(HttpClient whisperHttpClient, TranslateConfig config)
    {
        
        _config = config;
        _whisperHttpClient = whisperHttpClient;
    }

    
    public async Task<(bool success, string filePath)> TranscribeVideoFile(string mp3FilePath, string outputFilePath)
    {
        string output = "";
        await AnsiConsole.Status()
                .AutoRefresh(true)
                .Spinner(Spinner.Known.Default)
                .StartAsync("[yellow]Beginning subtitle for file[/]" + Path.GetFileName(mp3FilePath),async ctx =>
                {
                  
                        ctx.Status($"Beginning Subtitle Transcription for file, this will take a few minutes. {mp3FilePath}");
                        ctx.Refresh();
                    
                        await using var stream = System.IO.File.OpenRead(mp3FilePath);
                        using var request = new HttpRequestMessage(HttpMethod.Post, "asr");
                        using var content = new MultipartFormDataContent
                        {
                            { new StringContent("transcribe"), "task" },
                            { new StringContent("en"), "language" },
                            { new StringContent("srt"), "output" },
                            { new StreamContent(stream), "audio_file", Path.GetFileName(mp3FilePath) }
                        };

                        request.Content = content;

                      var response=  await _whisperHttpClient.SendAsync(request);
                      string output =Path.Combine( outputFilePath, Path.ChangeExtension(mp3FilePath, "srt"));
                      await File.WriteAllBytesAsync(output, await response.Content.ReadAsByteArrayAsync());
                   
                      ctx.Status($"[green]Cpmpleted Subtitle Transcription for file.[/] {mp3FilePath}");
                     ctx.Refresh();
                     return (true, output);

                });
            

     
            return (true, outputFilePath);

        }
    public  async Task<(bool success, string filePath)> ExtractAudioFromVideoFile(string videoFilePath, string outputFilePath)
    {
        string     output =Path.Combine( outputFilePath, Path.ChangeExtension(videoFilePath, "mp3"));
        if(File.Exists(output)) return (true, output);
        await AnsiConsole.Status()
                .AutoRefresh(true)
                .Spinner(Spinner.Known.Default)
                .StartAsync("[yellow]Beginning mp3 extraction for file[/]" + Path.GetFileName(videoFilePath),async ctx =>
                {
               
                    var conversion =await FFmpeg.Conversions.FromSnippet.ExtractAudio( videoFilePath, output);
                    conversion.SetOverwriteOutput(true);
                    conversion.UseMultiThread(Environment.ProcessorCount);
                    ctx.Spinner(Spinner.Known.Dots);
                    ctx.Status("[green]Starting conversion[/]");
                    conversion.OnProgress +=  (sender, args) =>
                    {
                        ctx.Status($"{args.Duration}/{args.TotalLength}   {Math.Round((double)args.Percent)}% {videoFilePath}");
                        ctx.Refresh();
                    };
                    await conversion.Start();
                  
                });
            

     
            return (true, output);

        }
    
}