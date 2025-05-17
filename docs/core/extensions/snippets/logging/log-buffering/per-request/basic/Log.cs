using Microsoft.Extensions.Logging;

namespace PerRequestLogBufferingBasic;

internal static partial class Log
{
    [LoggerMessage(Level = LogLevel.Error, Message = "Request {id} failed")]
    public static partial void ErrorMessage(this ILogger logger, int id);

    [LoggerMessage(Level = LogLevel.Information, Message = "Request {id} started.")]
    public static partial void RequestStarted(this ILogger logger, int id);

    [LoggerMessage(Level = LogLevel.Information, Message = "Request {id} ended.")]
    public static partial void RequestEnded(this ILogger logger, int id);

    [LoggerMessage(Level = LogLevel.Information, Message = "Exception handling finished for request {id}.")]
    public static partial void ExceptionHandlingFinished(this ILogger logger, int id);
}
