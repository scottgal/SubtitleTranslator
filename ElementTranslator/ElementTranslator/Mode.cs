namespace ElementTranslator;

[Flags]
public enum Mode
{   Extract = 1,
    Translate = 2,
    Transcribe= 4,
    TranscribeAndTranslate = Extract | Translate | Transcribe
}