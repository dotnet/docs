using WorkerServiceOptions.Example.Extensions;

namespace WorkerServiceOptions.Example;

public class Worker : BackgroundService
{
    private readonly ILogger<Worker> _logger;
    private readonly PriorityQueue _priorityQueue;

    public Worker(ILogger<Worker> logger, PriorityQueue priorityQueue) =>
        (_logger, _priorityQueue) = (logger, priorityQueue);

    protected override async Task ExecuteAsync(
        CancellationToken stoppingToken)
    {
        using IDisposable? scope = _logger.ProcessingWorkScope(DateTime.Now);
        while (!stoppingToken.IsCancellationRequested)
        {
            WorkItem? nextItem = _priorityQueue.ProcessNextHighestPriority();
            try
            {
                if (nextItem is not null)
                {
                    _logger.PriorityItemProcessed(nextItem);
                }
            }
            catch (Exception ex)
            {
                _logger.FailedToProcessWorkItem(ex);
            }

            await Task.Delay(1000, stoppingToken);
        }
    }
}
