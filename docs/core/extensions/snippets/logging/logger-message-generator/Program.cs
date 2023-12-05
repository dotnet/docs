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
logger.PlaceOfResidence(logLevel: LogLevel.Information, name: "Liana", city: "Seattle");

readonly file record struct SampleObject { }

public static partial class Log
{
    [LoggerMessage(EventId = 23, Message = "{Name} lives in {City}.")]
    public static partial void PlaceOfResidence(
        this ILogger logger,
        LogLevel logLevel,
        string name,
        string city);
}
