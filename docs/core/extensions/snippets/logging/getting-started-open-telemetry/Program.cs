using Microsoft.Extensions.Logging;
using OpenTelemetry.Logs;

using ILoggerFactory factory = LoggerFactory.Create(builder =>
{
    builder.AddOpenTelemetry(logging =>
    {
        logging.AddOtlpExporter();
    });
});
ILogger logger = factory.CreateLogger("Program");
logger.LogInformation("Hello World! Logging is {description}.", "fun");
