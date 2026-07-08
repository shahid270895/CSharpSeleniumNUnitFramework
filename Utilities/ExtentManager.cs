using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports.Reporter.Config;

namespace LearningNUnit2026.Utilities;

public class ExtentManager
{
    private static ExtentReports extent = null!;
    private static ExtentSparkReporter sparkReporter = null!;
    public static ExtentTest test = null!;

    public static ExtentReports GetExtent()
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

            extent.AddSystemInfo("Tester", Environment.UserName);
            extent.AddSystemInfo("Framework", "NUnit");
            extent.AddSystemInfo("Language", "C#");
            extent.AddSystemInfo("Automation Tool", "Selenium");
            extent.AddSystemInfo("Browser", ConfigReader.Browser.ToString());
            extent.AddSystemInfo("Environment", ConfigReader.Environment.ToString());
            extent.AddSystemInfo("OS", Environment.OSVersion.ToString());
        }

        return extent;
    }

    public static void CreateTest(string testName)
    {
        test = GetExtent().CreateTest(testName);
    }
}