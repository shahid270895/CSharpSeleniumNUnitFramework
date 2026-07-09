using Microsoft.Extensions.Configuration;

namespace LearningNUnit2026.Utilities;

public static class ConfigReader
{
    private static readonly IConfigurationRoot configuration;

    static ConfigReader()
    {
        configuration = new ConfigurationBuilder()
            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .Build();
    }

    public static BrowserType Browser
    {
        get
        {
            string? browser = System.Environment.GetEnvironmentVariable("Browser");
            if (string.IsNullOrWhiteSpace(browser))
            {
                browser = configuration["Browser"];
            }
            return Enum.Parse<BrowserType>(browser!, true);
        }
    }

    public static EnvironmentType Environment
    {
        get
        {
            string? environment = System.Environment.GetEnvironmentVariable("Environment");
            if (string.IsNullOrWhiteSpace(environment))
                environment = configuration["Environment"];
            return Enum.Parse<EnvironmentType>(environment!, true);
        }
    }

    public static string BaseUrl => configuration[$"Urls:{Environment}"]!;

    public static int ImplicitWait => int.Parse(configuration["ImplicitWait"]!);

    public static int ExplicitWait => int.Parse(configuration["ExplicitWait"]!);

    public static string ScreenshotPath => configuration["ScreenshotPath"]!;

    public static int RetryCount => int.Parse(configuration["RetryCount"]!);

    public static bool Headless
    {
        get
        {
            string? headless = System.Environment.GetEnvironmentVariable("Headless");
            if (string.IsNullOrWhiteSpace(headless))
                headless = configuration["Headless"];
            return bool.Parse(headless!);
        }
    }
    public static CategoryType TestCategory
    {
        get
        {
            string? category = System.Environment.GetEnvironmentVariable("TestCategory");
            if (string.IsNullOrWhiteSpace(category))
                category = configuration["TestCategory"];

            return Enum.Parse<CategoryType>(category!, true);
        }
    }
}
