using System.Text.Json;
using Microsoft.Extensions.Logging;

using ILoggerFactory loggerFactory = LoggerFactory.Create(
    builder =>
    builder.AddJsonConsole(
        options =>
        options.JsonWriterOptions = new JsonWriterOptions()
        {
            Indented = true
        }));

ILogger<SampleObject> logger = loggerFactory.CreateLogger<SampleObject>();
logger.CustomLogEvent(LogLevel.Information, "Liana", "Seattle");

public class SampleObject { }

public static partial class Log
{
    [LoggerMessage(EventId = 23)]
    public static partial void CustomLogEvent(
        this ILogger logger,
        LogLevel logLevel,
        string name,
        string city);
}
