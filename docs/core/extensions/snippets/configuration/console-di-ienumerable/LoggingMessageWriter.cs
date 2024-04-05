using Microsoft.Extensions.Logging;

namespace ConsoleDI.IEnumerableExample;

public sealed class LoggingMessageWriter(
    ILogger<LoggingMessageWriter> logger)
    : IMessageWriter
{
    public void Write(string message) =>
        logger.LogInformation("Info: {Msg}", message);
}
