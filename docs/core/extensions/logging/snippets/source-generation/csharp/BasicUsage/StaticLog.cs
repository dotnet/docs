using Microsoft.Extensions.Logging;

namespace BasicUsage.Static;

// <StaticLogMethod>
public static partial class Log
{
    [LoggerMessage(
        EventId = 0,
        Level = LogLevel.Critical,
        Message = "Could not open socket to `{HostName}`")]
    public static partial void CouldNotOpenSocket(
        ILogger logger, string hostName);
}
// </StaticLogMethod>
