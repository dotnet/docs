using Microsoft.Extensions.Logging;

namespace LogMethodAnatomy;

public static partial class LogMethods
{
    // <ValidLogMethod>
    // This is a valid attribute usage
    [LoggerMessage(
        EventId = 110, Level = LogLevel.Debug, Message = "M1 {Ex3} {Ex2}")]
    public static partial void ValidLogMethod(
        ILogger logger,
        Exception ex,
        Exception ex2,
        Exception ex3);
    // </ValidLogMethod>
}
