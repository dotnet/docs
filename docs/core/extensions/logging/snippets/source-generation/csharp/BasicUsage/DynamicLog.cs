using Microsoft.Extensions.Logging;

namespace BasicUsage.Dynamic;

// <DynamicLogLevel>
public static partial class Log
{
    [LoggerMessage(
        EventId = 0,
        Message = "Could not open socket to `{HostName}`")]
    public static partial void CouldNotOpenSocket(
        ILogger logger,
        LogLevel level,
        string hostName);
}
// </DynamicLogLevel>
