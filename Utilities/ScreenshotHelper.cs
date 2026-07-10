using OpenQA.Selenium;

namespace SpecFlowAutomationFramework2026.Utilities;

public static class ScreenshotHelper
{
    public static string CaptureScreenshot(IWebDriver driver, string testName)
    {
        string folderPath = PathHelper.ScreenshotFolder;

        if (!Directory.Exists(folderPath))
        {
            Directory.CreateDirectory(folderPath);
        }

        string fileName = testName + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".png";

        string filePath = Path.Combine(folderPath, fileName);

        Screenshot screenshot = ((ITakesScreenshot)driver).GetScreenshot();

        screenshot.SaveAsFile(filePath);

        return filePath;
    }
}
