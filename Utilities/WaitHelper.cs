using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace LearningNUnit2026.Utilities;

public class WaitHelper
{
    private WebDriverWait wait;

    public WaitHelper(IWebDriver driver)
    {
        wait = new WebDriverWait(driver, TimeSpan.FromSeconds(ConfigReader.ExplicitWait));
    }

    public IWebElement WaitForElementVisible(By locator)
    {
        return wait.Until(driver =>
        {
            IWebElement element = driver.FindElement(locator);

            return element.Displayed ? element : null;
        });
    }

    public IWebElement WaitForElementClickable(By locator)
    {
        return wait.Until(driver =>
        {
            IWebElement element = driver.FindElement(locator);

            return element.Enabled ? element : null;
        });
    }

    public void WaitForTitle(string expectedTitle)
    {
        wait.Until(driver => driver.Title == expectedTitle);
    }

    public void WaitForUrl(string expectedUrl)
    {
        wait.Until(driver => driver.Url.Contains(expectedUrl));
    }

    public bool WaitForElementToDisappear(By locator)
    {
        return wait.Until(driver =>
        {
            try
            {
                return !driver.FindElement(locator).Displayed;
            }
            catch (NoSuchElementException)
            {
                return true;
            }
        });
    }

    public IAlert WaitForAlert()
    {
        return wait.Until(driver =>
        {
            try
            {
                return driver.SwitchTo().Alert();
            }
            catch (NoAlertPresentException)
            {
                return null;
            }
        });
    }

    public void WaitForFrameAndSwitch(By frameLocator)
    {
        wait.Until(driver =>
        {
            IWebElement frame = driver.FindElement(frameLocator);

            driver.SwitchTo().Frame(frame);

            return true;
        });
    }

    public bool WaitForTextPresent(By locator, string expectedText)
    {
        return wait.Until(driver =>
        {
            return driver.FindElement(locator).Text.Contains(expectedText);
        });
    }

}