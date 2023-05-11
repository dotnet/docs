using Console.ExampleFormatters.Custom;
using Microsoft.Extensions.Logging;

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
