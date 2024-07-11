using Serilog;

public static class LoggingConfig
{
    static LoggingConfig()
    {
        Log.Logger = new LoggerConfiguration()
            .WriteTo.Console()
            .WriteTo.File("logfile.txt", rollingInterval: RollingInterval.Day)
            .CreateLogger();
    }

    public static void Configure()
    {
    }
}
