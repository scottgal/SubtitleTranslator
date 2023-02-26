using System.Collections.Concurrent;
using System.Net.Http.Json;
using System.Text.Json.Serialization;

namespace ElementTranslator;

public class LibreTranslateService
{
    public async Task<(bool success, string translatedText)> TranslateAsync(HttpClient httpClient, string test,
        string sourceLanguage,
        string targetLanguage, ConcurrentDictionary<string, string> cache)
    {
        if (cache.TryGetValue(test, out var value))
        {
            Debug.WriteLine(
                $"_____________________________________SKIP FOR {value}_____________________________________");
            return (true, value);
        }

        var urlEncodedContent = new FormUrlEncodedContent(new Dictionary<string, string>
        {
            {
                "q",
                test
            },
            {
                "source",
                sourceLanguage
            },
            {
                "target",
                targetLanguage
            }
        });


        var content = (HttpContent)urlEncodedContent;
        string stringResp;
        try
        {
            var res =
                await httpClient.PostAsync("/translate", content);
            stringResp = await res.Content.ReadAsStringAsync();
        }
        catch (Exception e)
        {
            AnsiConsole.WriteException(e);
            return (success: false, "");
        }
    

    var ret = JsonSerializer.Deserialize(stringResp, TranslatorJsonContext.Default.TranslateResponse);
        cache.TryAdd(test, ret.TranslatedText);
         return (success: true, ret.TranslatedText);
    }

    public async Task<List<Languages>?> GetSupportedLanguagesAsync(HttpClient httpClient)
    {
        return await httpClient.GetFromJsonAsync("/languages", TranslatorJsonContext.Default.ListLanguages);
    }

    internal class TranslateResponse
    {
        [JsonPropertyName("translatedText")] public string TranslatedText { get; set; }
    }
}