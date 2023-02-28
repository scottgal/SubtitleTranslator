namespace ElementTranslator;

[Flags]
public enum Mode
{   DetectLanguage = 1,
    Extract = 2,
    Translate = 4,
    Transcribe= 8,
   ExtractDetectTranslateTranscribe = Extract | DetectLanguage |  Translate | Transcribe,
    ExtractTranscribeTranslate = Extract |  Transcribe | Translate,
    ExtractTranscribe = Extract | Transcribe,
    TranscribeTranslate = Transcribe | Translate,

}