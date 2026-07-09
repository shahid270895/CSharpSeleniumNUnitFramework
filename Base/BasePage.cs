using LearningNUnit2026.Utilities;
using OpenQA.Selenium;
using Serilog;
using static Serilog.Log;

namespace LearningNUnit2026.Base;

public class BasePage
{
    public IWebDriver driver;
    public WaitHelper waitHelper;

    public BasePage(IWebDriver driver)
    {
        this.driver = driver;
        waitHelper = new WaitHelper(driver);
    }

    public void OpenApplication()
    {
        driver.Navigate().GoToUrl(ConfigReader.BaseUrl);
        FrameworkLogger.Info("Navigated to Url: " + ConfigReader.BaseUrl);
    }

    public void ClickOnElement(By locator)
    {
        waitHelper.WaitForElementClickable(locator).Click();
        FrameworkLogger.Info("Clicked on element.");
    }

    public void EnterText(By locator, string text)
    {
        IWebElement element = waitHelper.WaitForElementVisible(locator);
        element.Clear();
        element.SendKeys(text);
        FrameworkLogger.Info("Entered text");
    }

    public string GetElementText(By locator)
    {
        string text = waitHelper.WaitForElementVisible(locator).Text;
        FrameworkLogger.Info("Captured element text.");
        return text;
    }

    public bool IsDisplayed(By locator)
    {
        bool displayed = waitHelper.WaitForElementVisible(locator).Displayed;
        FrameworkLogger.Info("Element displayed.");
        return displayed;
    }

    public void WaitForPageTitle(string expectedTitle)
    {
        waitHelper.WaitForTitle(expectedTitle);
    }

    public string GetPageTitle()
    {
        return driver.Title;
    }

    public List<string> GetListValues(By locator)
    {
        var elements = waitHelper.WaitForAllVisibleElements(locator);
        List<string> elementsName = new List<string>();
        foreach (var ele in elements)
        {
            elementsName.Add(ele.Text);
        }
        FrameworkLogger.Info("All Elements displayed.");
        return elementsName;
    }
}
