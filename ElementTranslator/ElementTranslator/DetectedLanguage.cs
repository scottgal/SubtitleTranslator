using System.Text.Json.Serialization;

namespace ElementTranslator;
public class WhisperDetectLanguage
{
    [JsonPropertyName("detected_language")]
    public string DetectedLanguage { get; set; }

    [JsonPropertyName("langauge_code")]
    public string LangaugeCode { get; set; }
}