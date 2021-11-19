namespace App.WindowsService;

public sealed class WindowsBackgroundService : BackgroundService
{
    private readonly JokeService _jokeService;
    private readonly ILogger<WindowsBackgroundService> _logger;

    public WindowsBackgroundService(
        JokeService jokeService,
        ILogger<WindowsBackgroundService> logger) =>
        (_jokeService, _logger) = (jokeService, logger);

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            string joke = await _jokeService.GetJokeAsync();
            _logger.LogWarning(joke);

            await Task.Delay(TimeSpan.FromMinutes(1), stoppingToken);
        }
    }
}
