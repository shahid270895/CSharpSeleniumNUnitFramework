using System.Text.Json;

namespace SpecFlowAutomationFramework2026.Utilities;

public static class JsonDataReader
{
    private static JsonDocument? jsonDocument;

    public static void LoadJson(string fileName)
    {
        string filePath = Path.Combine(PathHelper.TestDataFolder, fileName);

        if (!File.Exists(filePath))
        {
            throw new FileNotFoundException($"JSON file not found: {filePath}");
        }

        jsonDocument = JsonDocument.Parse(File.ReadAllText(filePath));
    }

    public static string GetValue(params string[] keys)
    {
        if (jsonDocument == null)
        {
            throw new InvalidOperationException("JSON file is not loaded. Call LoadJson() first.");
        }

        JsonElement element = jsonDocument.RootElement;

        foreach (string key in keys)
        {
            element = element.GetProperty(key);
        }

        return element.GetString() ?? string.Empty;
    }
}
