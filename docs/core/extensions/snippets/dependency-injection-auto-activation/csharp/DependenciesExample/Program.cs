using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

var services = new ServiceCollection();

services.AddLogging();
// <snippet>
services.AddActivatedSingleton<StartupTaskRunner>();
// </snippet>

var provider = services.BuildServiceProvider();

// <StartupTaskRunner>
public class StartupTaskRunner
{
    private readonly ILogger<StartupTaskRunner> _logger;

    public StartupTaskRunner(ILogger<StartupTaskRunner> logger)
    {
        _logger = logger;
        _logger.LogInformation("Running startup tasks...");
        RunTasks();
    }

    private void RunTasks()
    {
        // Execute startup tasks
        _logger.LogInformation("Startup tasks completed.");
    }
}
// </StartupTaskRunner>
