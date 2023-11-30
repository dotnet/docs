namespace App.SignalCompletionService;

public sealed class Worker : BackgroundService
{
    private readonly IHostApplicationLifetime _hostApplicationLifetime;
    private readonly ILogger<Worker> _logger;

    public Worker(
        IHostApplicationLifetime hostApplicationLifetime, ILogger<Worker> logger) =>
        (_hostApplicationLifetime, _logger) = (hostApplicationLifetime, logger);

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        // TODO: implement single execution logic here.
        _logger.LogInformation(
            "Worker running at: {time}", DateTimeOffset.Now);

        await Task.Delay(1000, stoppingToken);

        // When completed, the entire app host will stop.
        _hostApplicationLifetime.StopApplication();
    }
}
