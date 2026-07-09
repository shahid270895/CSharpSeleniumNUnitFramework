using System.Text.Json;

namespace LearningNUnit2026.Utilities;

public static class JsonDataReader
{
    private static JsonDocument? jsonDocument;

    public static void LoadJson(string fileName)
    {
        string filePath = Path.Combine(PathHelper.TestDataFolder, fileName);

        jsonDocument = JsonDocument.Parse(File.ReadAllText(filePath));
    }

    public static string GetValue(params string[] keys)
    {
        JsonElement element = jsonDocument!.RootElement;

        foreach (string key in keys)
        {
            element = element.GetProperty(key);
        }

        return element.GetString()!;
    }
}
