using Microsoft.Extensions.Logging;

namespace LogSamplingCodeConfig;

internal static partial class Log
{
    [LoggerMessage(EventId = 1001, Level = LogLevel.Information, Message = "Noisy log message in my application.")]
    public static partial void NoisyMessage(this ILogger logger);
}
