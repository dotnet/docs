namespace App.ScopedService;

public sealed class DefaultScopedProcessingService(
    ILogger<DefaultScopedProcessingService> logger) : IScopedProcessingService
{
    private readonly string _instanceId = Guid.NewGuid().ToString();

    public Task DoWorkAsync(CancellationToken stoppingToken)
    {
        logger.LogInformation(
            "{ServiceName} doing work, instance ID: {Id}",
            nameof(DefaultScopedProcessingService),
            _instanceId);

        return Task.CompletedTask;
    }
}
