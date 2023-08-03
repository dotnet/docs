using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;

namespace Logging.LibraryAuthors;

public class NonDiExampleService
{
    private readonly ILogger<NonDiExampleService> _logger;

    public NonDiExampleService() =>
        _logger = NullLoggerFactory.Instance.CreateLogger<NonDiExampleService>();

    public void DoSomething()
    {
        if (_logger.IsEnabled(LogLevel.Information))
        {
            _logger.LogInformation("Doing work...");
        }
    }
}
