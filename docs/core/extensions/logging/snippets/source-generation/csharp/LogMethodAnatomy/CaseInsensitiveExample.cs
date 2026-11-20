using Microsoft.Extensions.Logging;

namespace LogMethodAnatomy;

// <CaseInsensitiveNames>
public partial class LoggingExample
{
    private readonly ILogger _logger;

    public LoggingExample(ILogger logger)
    {
        _logger = logger;
    }

    [LoggerMessage(
        EventId = 10,
        Level = LogLevel.Information,
        Message = "Welcome to {City} {Province}!")]
    public partial void LogMethodSupportsPascalCasingOfNames(
        string city, string province);

    public void TestLogging()
    {
        LogMethodSupportsPascalCasingOfNames("Vancouver", "BC");
    }
}
// </CaseInsensitiveNames>
