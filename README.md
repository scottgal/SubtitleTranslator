# SubtitleTranslator

Little commandline Subtitle translator. Uses LibreTranslate as a front end. 

Uses translate.json to configure translation.

Should be straightforward, specify the srt file, source language & languages you want to translate (can also include "en"). The LibreTranslate Url is an instance of LibreTranslate which *does not* have API key - this is deliberate as a subtitle file will cause millions of requests. 

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

docker run -ti --rm -p 5000:5000 libretranslate/libretranslate:v1.3.8
![image](https://user-images.githubusercontent.com/503770/221415457-e73f040f-c083-4725-a47e-fce066a6a172.png)
