using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using Serilog;
using static Serilog.Log;


namespace LearningNUnit2026.Utilities;

public class DriverFactory
{
    public static IWebDriver LaunchBrowser()
    {
        IWebDriver driver;

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
                driver = new ChromeDriver(chromeOptions);
                FrameworkLogger.Info("Chrome Browser Launched Successfully.");
                FrameworkLogger.Info($"Headless Mode : {ConfigReader.Headless}");
                break;

            case BrowserType.Edge:
                EdgeOptions edgeOptions = new EdgeOptions();

                if (ConfigReader.Headless)
                {
                    edgeOptions.AddArgument("--headless=new");
                }
                driver = new EdgeDriver(edgeOptions);
                FrameworkLogger.Info("Edge Browser Launched Successfully.");
                FrameworkLogger.Info($"Headless Mode : {ConfigReader.Headless}");
                break;
                
            case BrowserType.Firefox:
                FirefoxOptions firefoxOptions = new FirefoxOptions();
                if (ConfigReader.Headless)
                {
                    firefoxOptions.AddArgument("--headless");
                }
                driver = new FirefoxDriver(firefoxOptions);
                FrameworkLogger.Info("Firefox Browser Launched Successfully.");
                FrameworkLogger.Info($"Headless Mode : {ConfigReader.Headless}");
                break;

            default:
                FrameworkLogger.Error("Invalid Browser.");
                throw new Exception("Invalid Browser Name");
        }

        driver.Manage().Window.Maximize();
        driver.Manage().Cookies.DeleteAllCookies();
        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(ConfigReader.ImplicitWait);

        return driver;
    }

    public static void CloseBrowser(IWebDriver driver)
    {
        if (driver != null)
        {
            driver.Quit();
            FrameworkLogger.Info("Browser Closed Successfully.");
        }
    }
}