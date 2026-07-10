using Serilog;

namespace SpecFlowAutomationFramework2026.Utilities;

public static class FrameworkLogger
{
    public static void Info(string message)
    {
        Log.Information(message);

        if (ExtentManager.HasCurrentTest)
        {
            ExtentManager.Test!.Info(message);
        }
    }

    public static void Warning(string message)
    {
        Log.Warning(message);

        if (ExtentManager.HasCurrentTest)
        {
            ExtentManager.Test!.Warning(message);
        }
    }

    public static void Error(string message)
    {
        Log.Error(message);

        if (ExtentManager.HasCurrentTest)
        {
            ExtentManager.Test!.Fail(message);
        }
    }
}
