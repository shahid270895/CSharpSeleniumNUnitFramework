using Serilog;

namespace LearningNUnit2026.Utilities;

public static class FrameworkLogger
{
    public static void Info(string message)
    {
        Log.Information(message);
        ExtentManager.test.Info(message);
    }

    public static void Warning(string message)
    {
        Log.Warning(message);
        ExtentManager.test.Warning(message);
    }

    public static void Error(string message)
    {
        Log.Error(message);
        ExtentManager.test.Fail(message);
    }

}