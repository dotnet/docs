using Microsoft.Extensions.Logging;

namespace LogMethodAnatomy;

public static partial class IndeterminateOrderLog
{
    // <IndeterminateParameterOrder>
    [LoggerMessage(
        EventId = 110,
        Level = LogLevel.Debug,
        Message = "M1 {Ex3} {Ex2}")]
    static partial void LogMethod(
        Exception ex,
        Exception ex2,
        Exception ex3,
        ILogger logger);
    // </IndeterminateParameterOrder>
}
