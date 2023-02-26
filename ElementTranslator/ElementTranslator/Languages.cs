using System.Text.Json.Serialization;

namespace ElementTranslator;

public class Languages
{
    [JsonPropertyName("code")] public string code { get; set; }

    [JsonPropertyName("name")] public string name { get; set; }

    [JsonPropertyName("targets")] public List<string> targets { get; set; }
}