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

    public static BrowserType Browser => Enum.Parse<BrowserType>(configuration["Browser"]!, true);

    public static EnvironmentType Environment => Enum.Parse<EnvironmentType>(configuration["Environment"]!, true);

    public static string BaseUrl => configuration[$"Urls:{Environment}"]!;

    public static int ImplicitWait => int.Parse(configuration["ImplicitWait"]!);

    public static int ExplicitWait => int.Parse(configuration["ExplicitWait"]!);

    public static string ScreenshotPath => configuration["ScreenshotPath"]!;

    public static int RetryCount => int.Parse(configuration["RetryCount"]!);

    public static bool Headless => bool.Parse(configuration["Headless"]!);

}