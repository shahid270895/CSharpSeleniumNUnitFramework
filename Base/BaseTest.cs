// using AventStack.ExtentReports;
// using SpecFlowAutomationFramework2026.Pages;
// using SpecFlowAutomationFramework2026.Utilities;
// using OpenQA.Selenium;
// using Serilog;
// using static Serilog.Log;

// namespace SpecFlowAutomationFramework2026.Base;

// public class BaseTest
// {
//     protected IWebDriver driver = null!;
//     protected LoginPage loginPage = null!;
//     protected DashboardPage dashboardPage = null!;

//     [SetUp]
//     public void Setup()
//     {
//         Console.WriteLine("Launching Browser...");
//         ExtentManager.CreateTest(TestContext.CurrentContext.Test.Name);
//         driver = DriverFactory.LaunchBrowser();
//         JsonDataReader.LoadJson("LoginData.json");
//         loginPage = new LoginPage(driver);
//         dashboardPage = new DashboardPage(driver);
//     }

//     [TearDown]
//     public void TearDown()
//     {
//         var status = TestContext.CurrentContext.Result.Outcome.Status;

//         if (status == NUnit.Framework.Interfaces.TestStatus.Failed)
//         {
//             string errorMessage =
//                 TestContext.CurrentContext.Result.Message ?? "No error message available.";
//             string stackTrace =
//                 TestContext.CurrentContext.Result.StackTrace ?? "No stack trace available.";

//             ExtentManager.Test.Fail(errorMessage);
//             ExtentManager.Test.Fail(stackTrace);

//             string screenshotPath = ScreenshotHelper.CaptureScreenshot(
//                 driver,
//                 TestContext.CurrentContext.Test.Name
//             );

//             string relativePath = $"Screenshots/{Path.GetFileName(screenshotPath)}";

//             ExtentManager.Test.AddScreenCaptureFromPath(relativePath, "Failure Screenshot");
//         }
//         else if (status == NUnit.Framework.Interfaces.TestStatus.Passed)
//         {
//             ExtentManager.Test.Pass("Test Passed");
//         }
//         else
//         {
//             ExtentManager.Test.Skip("Test Skipped");
//         }

//         DriverFactory.CloseBrowser();
//     }

//     [OneTimeSetUp]
//     public void BeforeSuite()
//     {
//         Console.WriteLine("========== Test Suite Started ==========");
//         FrameworkLogger.Info($"Browser     : {ConfigReader.Browser}");
//         FrameworkLogger.Info($"Environment : {ConfigReader.Environment}");
//         FrameworkLogger.Info($"Headless    : {ConfigReader.Headless}");
//         FrameworkLogger.Info($"Test Suite  : {ConfigReader.TestCategory}");
//         LoggerHelper.ConfigureLogger();
//         ExtentManager.InitializeReport();
//     }

//     [OneTimeTearDown]
//     public void AfterSuite()
//     {
//         ExtentManager.InitializeReport().Flush();
//         LoggerHelper.CloseLogger();
//         Console.WriteLine("========== Test Suite Finished ==========");
//     }
// }
