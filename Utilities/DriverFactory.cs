using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using Serilog;
using static Serilog.Log;

namespace LearningNUnit2026.Utilities;

public static class DriverFactory
{
    private static readonly ThreadLocal<IWebDriver> driver = new();

    public static IWebDriver Driver => driver.Value!;

    public static IWebDriver LaunchBrowser()
    {
        IWebDriver browser;

        switch (ConfigReader.Browser)
        {
            case BrowserType.Chrome:
                ChromeOptions chromeOptions = new ChromeOptions();
                if (ConfigReader.Headless)
                {
                    chromeOptions.AddArgument("--headless=new");
                }
                chromeOptions.AddArgument("--start-maximized");
                chromeOptions.AddArgument("--disable-gpu");
                chromeOptions.AddArgument("--no-sandbox");
                chromeOptions.AddArgument("--disable-dev-shm-usage");
                browser = new ChromeDriver(chromeOptions);
                FrameworkLogger.Info("Chrome Browser Launched Successfully.");
                break;

            case BrowserType.Edge:
                EdgeOptions edgeOptions = new EdgeOptions();

                if (ConfigReader.Headless)
                {
                    edgeOptions.AddArgument("--headless=new");
                }
                browser = new EdgeDriver(edgeOptions);
                FrameworkLogger.Info("Edge Browser Launched Successfully.");
                break;

            case BrowserType.Firefox:
                FirefoxOptions firefoxOptions = new FirefoxOptions();
                if (ConfigReader.Headless)
                {
                    firefoxOptions.AddArgument("--headless");
                }
                browser = new FirefoxDriver(firefoxOptions);
                FrameworkLogger.Info("Firefox Browser Launched Successfully.");
                break;

            default:
                FrameworkLogger.Error("Invalid Browser.");
                throw new Exception("Invalid Browser Name");
        }
        driver.Value = browser;
        browser.Manage().Window.Maximize();
        browser.Manage().Cookies.DeleteAllCookies();
        browser.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(ConfigReader.ImplicitWait);

        return browser;
    }

    public static void CloseBrowser()
    {
        if (driver.Value != null)
        {
            driver.Value.Quit();
            driver.Value.Dispose();
            driver.Value = null!;
            FrameworkLogger.Info("Browser Closed Successfully.");
        }
    }
}
