﻿namespace App.QueueService;

public sealed class MonitorLoop(
    IBackgroundTaskQueue taskQueue,
    ILogger<MonitorLoop> logger,
    IHostApplicationLifetime applicationLifetime)
{
    private readonly CancellationToken _cancellationToken = applicationLifetime.ApplicationStopping;

    public void StartMonitorLoop()
    {
        logger.LogInformation($"{nameof(MonitorAsync)} loop is starting.");

        // Run a console user input loop in a background thread
        Task.Run(async () => await MonitorAsync());
    }

    private async ValueTask MonitorAsync()
    {
        while (!_cancellationToken.IsCancellationRequested)
        {
            var keyStroke = Console.ReadKey();
            if (keyStroke.Key == ConsoleKey.W)
            {
                // Enqueue a background work item
                await taskQueue.QueueBackgroundWorkItemAsync(BuildWorkItemAsync);
            }
        }
    }

    private async ValueTask BuildWorkItemAsync(CancellationToken token)
    {
        // Simulate three 5-second tasks to complete
        // for each enqueued work item

        int delayLoop = 0;
        var guid = Guid.NewGuid();

        logger.LogInformation("Queued work item {Guid} is starting.", guid);

        while (!token.IsCancellationRequested && delayLoop < 3)
        {
            try
            {
                await Task.Delay(TimeSpan.FromSeconds(5), token);
            }
            catch (OperationCanceledException)
            {
                // Prevent throwing if the Delay is cancelled
            }

            ++ delayLoop;

            logger.LogInformation("Queued work item {Guid} is running. {DelayLoop}/3", guid, delayLoop);
        }

        if (delayLoop is 3)
        {
            logger.LogInformation("Queued Background Task {Guid} is complete.", guid);
        }
        else
        {
            logger.LogInformation("Queued Background Task {Guid} was cancelled.", guid);
        }
    }
}
