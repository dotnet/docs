using Microsoft.Extensions.Logging;

namespace Console.ExampleFormatters.Simple;

class Program
{
    static void Main()
    {
        using ILoggerFactory loggerFactory =
            LoggerFactory.Create(builder =>
                builder.AddSimpleConsole(options =>
                {
                    options.IncludeScopes = true;
                    options.SingleLine = true;
                    options.TimestampFormat = "hh:mm:ss ";
                }));

        ILogger<Program> logger = loggerFactory.CreateLogger<Program>();
        using (logger.BeginScope("[scope is enabled]"))
        {
            logger.LogInformation("Hello World!");
            logger.LogInformation("Logs contain timestamp and log level.");
            logger.LogInformation("Each log message is fit in a single line.");
        }
    }
}
