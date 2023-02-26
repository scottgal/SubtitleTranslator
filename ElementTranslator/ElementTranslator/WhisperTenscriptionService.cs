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

    public  async Task<(bool success, string filePath)> ExtractAudioFromVideoFile(string videoFilePath, string outputFilePath)
    {

        string output = "";
         

            await AnsiConsole.Status()
                .AutoRefresh(true)
                .Spinner(Spinner.Known.Default)
                .StartAsync("[yellow]Initializing warp drive[/]",async ctx =>
                {
                    string output =Path.Combine( outputFilePath, Path.ChangeExtension(videoFilePath, "mp3"));
                    var conversion =await FFmpeg.Conversions.FromSnippet.ExtractAudio( videoFilePath, output);
                    conversion.SetOverwriteOutput(true);
                    conversion.UseMultiThread(Environment.ProcessorCount);
                    ctx.Spinner(Spinner.Known.Dots);
                    ctx.Status("[green]Starting conversion[/]");
                    conversion.OnProgress +=  (sender, args) =>
                    {
                        ctx.Status($"{args.Duration}/{args.TotalLength}{args.Percent}% {videoFilePath}");
                        ctx.Refresh();
                    };
                    await conversion.Start();
                  
                });
            

     
            return (true, output);

        }
    
}