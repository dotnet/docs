using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

// Add services to the container including logging
ServiceCollection services = new ServiceCollection();
services.AddLogging(builder => builder.AddConsole());
services.AddSingleton<Worker>();
IServiceProvider serviceProvider = services.BuildServiceProvider();

// Get the worker object from the container
Worker worker = serviceProvider.GetRequiredService<Worker>();

// Do some pretend work
worker.DoSomeWork(10, 20);

class Worker
{
    private readonly ILogger<Worker> _logger;

    public Worker(ILogger<Worker> logger)
    {
        _logger = logger;
    }

    public void DoSomeWork(int x, int y)
    {
        _logger.LogInformation("DoSomeWork was called. x={x}, y={y}", x, y);
    }
}
