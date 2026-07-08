using LearningNUnit2026.Pages;
using LearningNUnit2026.Utilities;
using OpenQA.Selenium;
using AventStack.ExtentReports;
using Serilog;
using static Serilog.Log;

namespace LearningNUnit2026.Base;

public class BaseTest
{
    protected IWebDriver driver = null!;
    protected static ExtentReports extent = null!;
    protected ExtentTest test = null!;
    protected LoginPage loginPage = null!;
    
    [SetUp]
    public void Setup()
    {
        Console.WriteLine("Launching Browser...");
        ExtentManager.CreateTest(TestContext.CurrentContext.Test.Name);
        test = ExtentManager.test;
        driver = DriverFactory.LaunchBrowser();
        JsonDataReader.LoadJson("LoginData.json");
        loginPage = new LoginPage(driver);
    }

    [TearDown]
    public void TearDown()
    {
        var status = TestContext.CurrentContext.Result.Outcome.Status;

        if (status == NUnit.Framework.Interfaces.TestStatus.Failed)
        {
            string errorMessage = TestContext.CurrentContext.Result.Message ?? "No error message available.";
            string stackTrace = TestContext.CurrentContext.Result.StackTrace ?? "No stack trace available.";

            test.Fail(errorMessage);
            test.Fail(stackTrace);

            string screenshotPath = ScreenshotHelper.CaptureScreenshot(driver, TestContext.CurrentContext.Test.Name);

            string relativePath = $"Screenshots/{Path.GetFileName(screenshotPath)}";

            test.AddScreenCaptureFromPath(relativePath, "Failure Screenshot");
        }
        else if (status == NUnit.Framework.Interfaces.TestStatus.Passed)
        {
            test.Pass("Test Passed");
        }
        else
        {
            test.Skip("Test Skipped");
        }

        DriverFactory.CloseBrowser(driver);
    }

    [OneTimeSetUp]
    public void BeforeSuite()
    {
        Console.WriteLine("========== Test Suite Started ==========");
        LoggerHelper.ConfigureLogger();
        extent = ExtentManager.GetExtent();
    }

    [OneTimeTearDown]
    public void AfterSuite()
    {
        extent.Flush();
        LoggerHelper.CloseLogger();
        Console.WriteLine("========== Test Suite Finished ==========");
    }
}