using System.Text.Json.Serialization;

namespace ElementTranslator;

[JsonSourceGenerationOptions(GenerationMode = JsonSourceGenerationMode.Default, WriteIndented = true)]
[JsonSerializable(typeof(List<Languages>))]
[JsonSerializable(typeof(LibreTranslateService.TranslateResponse))]
[JsonSerializable(typeof(Languages))]
[JsonSerializable(typeof(TranslateConfig))]
[JsonSerializable(typeof(WhisperDetectLanguage))]
internal partial class TranslatorJsonContext : JsonSerializerContext
{
}