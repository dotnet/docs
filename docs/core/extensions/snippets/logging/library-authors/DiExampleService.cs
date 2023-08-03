using Microsoft.Extensions.Logging;

namespace Logging.LibraryAuthors;

public class DiExampleService
{
    private readonly ILogger<DiExampleService> _logger;

    public DiExampleService(ILogger<DiExampleService> logger) =>
        _logger = logger;

    public void DoSomething()
    {
        if (_logger.IsEnabled(LogLevel.Information))
        {
            _logger.LogInformation("Doing work...");
        }
    }
}