namespace App.ScopedService;

public interface IScopedProcessingService
{
    Task DoWorkAsync(CancellationToken stoppingToken);
}
