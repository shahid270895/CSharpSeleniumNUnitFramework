using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;

namespace MyNamespace
{
    [Binding]
    public class GoogleSteps
    {
        IWebDriver driver = null!;

        public GoogleSteps() { }

        [Given(@"User opens Google")]
        public void GivenUserOpensGoogle()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(30);

            driver.Navigate().GoToUrl("https://www.google.com/");
            Thread.Sleep(2000);
        }

        [Then(@"Google page should be displayed")]
        public void ThenGooglePageShouldBeDisplayed()
        {
            Assert.That(driver.Title == "Google");
            driver.Quit();
        }
    }
}
