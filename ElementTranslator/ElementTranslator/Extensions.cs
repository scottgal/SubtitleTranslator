namespace ElementTranslator;

public static class Extensions
{
    public static bool IsFullPath(this string path)
    {
        return !string.IsNullOrWhiteSpace(path)
               && path.IndexOfAny(Path.GetInvalidPathChars().ToArray()) == -1
               && Path.IsPathRooted(path)
               && !Path.GetPathRoot(path)!.Equals(Path.DirectorySeparatorChar.ToString(), StringComparison.Ordinal);
    }

    public static T ToObject<T>(this JsonElement element)
    {
        var json = element.GetRawText();
        return JsonSerializer.Deserialize<T>(json);
    }

    public static T ToObject<T>(this JsonDocument document)
    {
        var json = document.RootElement.GetRawText();
        return JsonSerializer.Deserialize<T>(json);
    }
}