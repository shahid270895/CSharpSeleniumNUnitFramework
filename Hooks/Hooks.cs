using SpecFlowAutomationFramework2026.Utilities;
using TechTalk.SpecFlow;

namespace SpecFlowAutomationFramework2026.Hooks;

[Binding]
public class Hooks
{
    private readonly ScenarioContext scenarioContext;
    private readonly FeatureContext featureContext;
    private DateTime scenarioStartTime;

    public Hooks(ScenarioContext scenarioContext, FeatureContext featureContext)
    {
        this.scenarioContext = scenarioContext;
        this.featureContext = featureContext;
    }

    [BeforeTestRun]
    public static void BeforeTestRun()
    {
        LoggerHelper.ConfigureLogger();
        ExtentManager.InitializeReport();
        FrameworkLogger.Info("========== Test Execution Started ==========");
    }

    [BeforeScenario]
    public void BeforeScenario(ScenarioContext scenarioContext)
    {
        scenarioStartTime = DateTime.Now;

        ExtentManager.CreateTest(scenarioContext.ScenarioInfo.Title);

        ExtentManager.Test.AssignCategory(featureContext.FeatureInfo.Title);

        foreach (var tag in scenarioContext.ScenarioInfo.Tags)
        {
            ExtentManager.Test.AssignCategory(tag);
        }

        ExtentManager.Test.AssignAuthor(Environment.UserName);
        ExtentManager.Test.Info($"Browser      : {ConfigReader.Browser}");
        ExtentManager.Test.Info($"Environment  : {ConfigReader.Environment}");
        ExtentManager.Test.Info($"Headless     : {ConfigReader.Headless}");
        ExtentManager.Test.Info($"Thread ID    : {Environment.CurrentManagedThreadId}");
        ExtentManager.Test.Info($"Machine Name : {Environment.MachineName}");

        FrameworkLogger.Info($"Scenario Started : {scenarioContext.ScenarioInfo.Title}");

        DriverFactory.LaunchBrowser();

        JsonDataReader.LoadJson("LoginData.json");
    }

    [AfterScenario]
    public void AfterScenario(ScenarioContext scenarioContext)
    {
        TimeSpan executionTime = DateTime.Now - scenarioStartTime;
        ExtentManager.Test.Info($"Execution Time : {executionTime}");
        if (scenarioContext.TestError != null)
        {
            FrameworkLogger.Error(scenarioContext.TestError.Message);
            ExtentManager.Test.Fail(scenarioContext.TestError.Message);
            if (!string.IsNullOrWhiteSpace(scenarioContext.TestError.StackTrace))
            {
                ExtentManager.Test.Fail(scenarioContext.TestError.StackTrace);
            }

            string screenshotPath = ScreenshotHelper.CaptureScreenshot(
                DriverFactory.Driver,
                scenarioContext.ScenarioInfo.Title
            );

            string relativePath = $"Screenshots/{Path.GetFileName(screenshotPath)}";
            ExtentManager.Test.AddScreenCaptureFromPath(relativePath, "Failure Screenshot");
        }
        else
        {
            FrameworkLogger.Info($"Scenario Passed : {scenarioContext.ScenarioInfo.Title}");

            ExtentManager.Test.Pass("Scenario Passed");
        }

        DriverFactory.CloseBrowser();
    }

    [AfterTestRun]
    public static void AfterTestRun()
    {
        ExtentManager.InitializeReport().Flush();

        FrameworkLogger.Info("========== Test Execution Finished ==========");

        LoggerHelper.CloseLogger();
    }

    [BeforeFeature]
    public static void BeforeFeature(FeatureContext featureContext)
    {
        FrameworkLogger.Info("");
        FrameworkLogger.Info("=======================================");
        FrameworkLogger.Info($"Feature Started : {featureContext.FeatureInfo.Title}");
        FrameworkLogger.Info("=======================================");
    }

    [AfterFeature]
    public static void AfterFeature(FeatureContext featureContext)
    {
        FrameworkLogger.Info("=======================================");
        FrameworkLogger.Info($"Feature Finished : {featureContext.FeatureInfo.Title}");
        FrameworkLogger.Info("=======================================");
        FrameworkLogger.Info("");
    }
}
