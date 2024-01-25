using WorkerServiceOptions.Example.Extensions;

namespace WorkerServiceOptions.Example;

public sealed class Worker(
    ILogger<Worker> logger,
    PriorityQueue priorityQueue) : BackgroundService
{
    protected override async Task ExecuteAsync(
        CancellationToken stoppingToken)
    {
        using IDisposable? scope = logger.ProcessingWorkScope(DateTime.Now);
        while (!stoppingToken.IsCancellationRequested)
        {
            WorkItem? nextItem = priorityQueue.ProcessNextHighestPriority();
            try
            {
                if (nextItem is not null)
                {
                    logger.PriorityItemProcessed(nextItem);
                }
            }
            catch (Exception ex)
            {
                logger.FailedToProcessWorkItem(ex);
            }

            await Task.Delay(1_000, stoppingToken);
        }
    }
}
