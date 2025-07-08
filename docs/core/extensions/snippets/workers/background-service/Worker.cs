namespace App.WorkerService;

public sealed class Worker(ILogger<Worker> logger) : BackgroundService
{
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
            await Task.Delay(1_000, stoppingToken);
        }
    }
}
