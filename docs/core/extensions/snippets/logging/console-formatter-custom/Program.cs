using Microsoft.Extensions.Logging;

namespace Console.ExampleFormatters.Custom;

class Program
{
    static void Main()
    {
        using ILoggerFactory loggerFactory =
            LoggerFactory.Create(builder =>
                builder.AddCustomFormatter(options =>
                    options.CustomPrefix = " ~~~~~ "));

        ILogger<Program> logger = loggerFactory.CreateLogger<Program>();
        using (logger.BeginScope("TODO: Add logic to enable scopes"))
        {
            logger.LogInformation("Hello World!");
            logger.LogInformation("TODO: Add logic to enable timestamp and log level info.");
        }
    }
}
