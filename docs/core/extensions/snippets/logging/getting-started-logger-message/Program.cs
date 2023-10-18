using Microsoft.Extensions.Logging;

internal partial class Program
{
    static void Main(string[] args)
    {
        using ILoggerFactory factory = LoggerFactory.Create(builder => builder.AddConsole());
        ILogger logger = factory.CreateLogger("Program");
        LogStartupMessage(logger, "fun");
    }

    [LoggerMessage(Level = LogLevel.Information, Message = "Hello World! Logging is {description}.")]
    static partial void LogStartupMessage(ILogger logger, string description);
}
