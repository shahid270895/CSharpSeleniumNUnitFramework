#nullable enable
using System.IO;

namespace SpecFlowAutomationFramework2026.Utilities;

public static class PathHelper
{
    public static string ProjectRoot
    {
        get
        {
            DirectoryInfo? directory = new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory);

            while (directory != null)
            {
                if (directory.GetFiles("*.csproj").Length > 0)
                {
                    return directory.FullName;
                }

                directory = directory.Parent;
            }

            throw new DirectoryNotFoundException("Project root not found.");
        }
    }

    public static string ReportFolder => Path.Combine(ProjectRoot, "Reports");

    public static string ScreenshotFolder => Path.Combine(ReportFolder, "Screenshots");

    public static string LogFolder => Path.Combine(ReportFolder, "Logs");

    public static string TestDataFolder => Path.Combine(ProjectRoot, "TestData");

    public static string DownloadFolder => Path.Combine(ProjectRoot, "Downloads");
}
