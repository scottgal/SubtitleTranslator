namespace ElementTranslator;

[Flags]
public enum Mode
{
    Translate = 0,
    Transcribe= 1,
    TranscribeAndTranslate = Translate | Transcribe
}