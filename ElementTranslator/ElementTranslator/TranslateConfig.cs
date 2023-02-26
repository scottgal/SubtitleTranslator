﻿using System.Text.Json.Serialization;

namespace ElementTranslator;

public class TranslateConfig
{
    private string _destinationPath = "";

    
    public string SubtitleFilePath { get; set; } = "DefaultPath";

    public string SourceVideoFilePath { get; set; } = "DefaultPath";
    
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public Mode Mode { get; set; } = Mode.Translate;
    public string SourceLanguage { get; set; } = "en";

    public string[] Languages { get; set; }
    
    
    public string LibreTranslateUrl { get; set; } = "http://localhost:5000";
    
    public string WhisperAIUrl { get; set; } = "http://localhost:9000";

    public string DestinationPath
    {
        get
        {
            if (string.IsNullOrEmpty(_destinationPath))
                _destinationPath = Path.Combine(Path.GetDirectoryName(SubtitleFilePath), "translated");

            return _destinationPath;
        }
        set => _destinationPath = value;
    }
}