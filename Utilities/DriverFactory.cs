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
                driver = new ChromeDriver();
                FrameworkLogger.Info("Chrome Browser Launched Successfully.");
                break;

            case BrowserType.Edge:
                driver = new EdgeDriver();
                FrameworkLogger.Info("Edge Browser Launched Successfully.");
                break;

            case BrowserType.Firefox:
                driver = new FirefoxDriver();
                FrameworkLogger.Info("Firefox Browser Launched Successfully.");
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