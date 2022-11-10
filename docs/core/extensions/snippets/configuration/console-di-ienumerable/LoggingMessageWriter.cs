using Microsoft.Extensions.Logging;

namespace ConsoleDI.IEnumerableExample;

public sealed class LoggingMessageWriter : IMessageWriter
{
    private readonly ILogger<LoggingMessageWriter> _logger;

    public LoggingMessageWriter(ILogger<LoggingMessageWriter> logger) =>
        _logger = logger;

    public void Write(string message) =>
        _logger.LogInformation("Info: {Msg}", message);
}
