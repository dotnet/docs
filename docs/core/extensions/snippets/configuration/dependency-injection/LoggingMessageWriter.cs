namespace DependencyInjection.Example;

public class LoggingMessageWriter(
    ILogger<LoggingMessageWriter> logger) : IMessageWriter
{
    public void Write(string message) =>
        logger.LogInformation("Info: {Msg}", message);
}
