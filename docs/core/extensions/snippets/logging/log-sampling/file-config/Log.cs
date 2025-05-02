using Microsoft.Extensions.Logging;

namespace LogSamplingFileConfig;

internal static partial class Log
{
    [LoggerMessage(Level = LogLevel.Debug, Message = "Entered While loop in my application.")]
    public static partial void EnteredWhileLoop(this ILogger logger);

    [LoggerMessage(Level = LogLevel.Debug, Message = "Left While loop in my application.")]
    public static partial void LeftWhileLoop(this ILogger logger);

    [LoggerMessage(EventId = 1001, Level = LogLevel.Information, Message = "Noisy log message in my application.")]
    public static partial void NoisyMessage(this ILogger logger);
}
