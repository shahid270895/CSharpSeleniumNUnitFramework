using Serilog;
using Serilog.Events;

namespace SpecFlowAutomationFramework2026.Utilities;

public static class LoggerHelper
{
    public static void ConfigureLogger()
    {
        if (!Directory.Exists(PathHelper.LogFolder))
        {
            Directory.CreateDirectory(PathHelper.LogFolder);
        }

        Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Information()
            .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
            .Enrich.FromLogContext()
            .WriteTo.Console(
                outputTemplate: "[{Timestamp:HH:mm:ss}] [{Level:u3}] {Message:lj}{NewLine}{Exception}"
            )
            .WriteTo.File(
                Path.Combine(PathHelper.LogFolder, "AutomationLog-.txt"),
                rollingInterval: RollingInterval.Day,
                retainedFileCountLimit: 15,
                outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss} [{Level:u3}] {Message:lj}{NewLine}{Exception}"
            )
            .CreateLogger();
    }

    public static void CloseLogger()
    {
        Log.CloseAndFlush();
    }
}
