namespace App.ScopedService;

public class DefaultScopedProcessingService : IScopedProcessingService
{
    private int _executionCount;
    private readonly ILogger<DefaultScopedProcessingService> _logger;

    public DefaultScopedProcessingService(
        ILogger<DefaultScopedProcessingService> logger) =>
        _logger = logger;

    public async Task DoWorkAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            ++ _executionCount;

            _logger.LogInformation(
                "{ServiceName} working, execution count: {Count}",
                nameof(DefaultScopedProcessingService),
                _executionCount);

            await Task.Delay(10_000, stoppingToken);
        }
    }
}
