using Microsoft.Extensions.Logging;

namespace BasicUsage.PrimaryConstructor;

// <InstanceLogWithPrimaryCtor>
public partial class InstanceLoggingExample(ILogger logger)
{
    [LoggerMessage(
        EventId = 0,
        Level = LogLevel.Critical,
        Message = "Could not open socket to `{HostName}`")]
    public partial void CouldNotOpenSocket(string hostName);
}
// </InstanceLogWithPrimaryCtor>
