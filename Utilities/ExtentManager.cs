using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports.Reporter.Config;

namespace SpecFlowAutomationFramework2026.Utilities;

public static class ExtentManager
{
    private static ExtentReports extent = null!;
    private static ExtentSparkReporter sparkReporter = null!;
    private static readonly ThreadLocal<ExtentTest> test = new();
    public static ExtentTest Test => test.Value!;
    public static bool HasCurrentTest => test.Value != null;

    public static ExtentReports InitializeReport()
    {
        if (extent == null)
        {
            if (!Directory.Exists(PathHelper.ReportFolder))
            {
                Directory.CreateDirectory(PathHelper.ReportFolder);
            }

            string fileName = "ExtentReport_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".html";

            string reportPath = Path.Combine(PathHelper.ReportFolder, fileName);

            sparkReporter = new ExtentSparkReporter(reportPath);

            sparkReporter.Config.DocumentTitle = "Automation Execution Report";
            sparkReporter.Config.ReportName = "Learning NUnit Selenium Framework";
            sparkReporter.Config.Theme = Theme.Dark;

            extent = new ExtentReports();

            extent.AttachReporter(sparkReporter);

            string browser =
                Environment.GetEnvironmentVariable("Browser") ?? ConfigReader.Browser.ToString();

            string environment =
                Environment.GetEnvironmentVariable("Environment")
                ?? ConfigReader.Environment.ToString();

            string headless =
                Environment.GetEnvironmentVariable("Headless") ?? ConfigReader.Headless.ToString();

            extent.AddSystemInfo("Tester", Environment.UserName);
            extent.AddSystemInfo("Framework", "SpecFlow BDD");
            extent.AddSystemInfo("Language", "C#");
            extent.AddSystemInfo("Automation Tool", "Selenium");
            // extent.AddSystemInfo("Browser", ConfigReader.Browser.ToString());
            // extent.AddSystemInfo("Environment", ConfigReader.Environment.ToString());
            // extent.AddSystemInfo("Headless", ConfigReader.Headless.ToString());
            extent.AddSystemInfo("Browser", browser);
            extent.AddSystemInfo("Environment", environment);
            extent.AddSystemInfo("Headless", headless);
            extent.AddSystemInfo("Test Category", ConfigReader.TestCategory.ToString());
            extent.AddSystemInfo("OS", Environment.OSVersion.ToString());
        }

        return extent;
    }

    public static void CreateTest(string testName)
    {
        test.Value = InitializeReport().CreateTest(testName);
    }

    public static void FlushReport()
    {
        extent?.Flush();
    }
}
