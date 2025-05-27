using Microsoft.Extensions.Logging;

namespace GlobalLogBufferingCodeBased;

internal static partial class Log
{
    [LoggerMessage(Level = LogLevel.Error, Message = "ERROR log message in my application. {message}")]
    public static partial void ErrorMessage(this ILogger logger, string message);

    [LoggerMessage(Level = LogLevel.Information, Message = "INFORMATION log message in my application.")]
    public static partial void InformationMessage(this ILogger logger);
}
