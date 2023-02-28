# Video Transcriber and Subtitle Translator

This is purely a project I'm using to play with; no warranties are implied but you're free to do what you like with it.

This branch is an extension to thre original Subtitle Translator to add Media file (any supported by FFMPEG for audio extraction) -> MP3 file-> Subtitle file -> Translated Subtitle files

It does this using WhisperAI and LibreTranslate Docker containers. 
To run Whisper AI -
`docker run -d -p 9000:9000 -e ASR_MODEL=base onerahmet/openai-whisper-asr-webservice:x1.0.41

Little commandline Subtitle translator. Uses LibreTranslate as a front end. 
![image](https://user-images.githubusercontent.com/503770/221427796-042cd914-0467-4d14-8c41-73e262218524.png)

Uses translate.json to configure translation.

Should be straightforward, specify the srt file, source language & languages you want to translate (can also include "en"). The LibreTranslate Url is an instance of LibreTranslate which *does not* have API key - this is deliberate as a subtitle file will cause millions of requests. 

`docker run -ti --rm -p 5000:5000 libretranslate/libretranslate:v1.3.8`

When it runs the app will use the outpout path to store .tmp files. These are valid SRT files but as LibreTranslate can be a little glitchy it protectsa against this by making translations reentrant. Every 100 translations causes the tmp file to be recreated; when complete this file is 'moved' tom the final srt.  

On load these tmp files are used to pre-load translated items. 

```json
{
  "SubtitleFilePath": "F:\\GMV\\Good.Morning.Vietnam.1987.720p.BrRip.x264.YIFY.en.srt",
  "SourceLanguage": "en",
  "Languages": [
    "ar",
    "az",
    "ca",
    "cs",
    "da",
    "de",
    "el",
    "eo",
    "es",
    "fa",
    "fi",
    "fr",
    "ga",
    "he",
    "hi",
    "hu",
    "id",
    "it",
    "ja",
    "ko",
    "nl",
    "pl",
    "pt",
    "ru",
    "sk",
    "sv",
    "tr",
    "uk",
    "zh"
  ],
  "LibreTranslateUrl":  "http://localhost:5000",
  "DestinationPath": "F:\\GMV\\translated\\"
}
```


