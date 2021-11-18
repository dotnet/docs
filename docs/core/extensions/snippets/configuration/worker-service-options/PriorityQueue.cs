namespace WorkerServiceOptions.Example;

public class PriorityQueue
{
    private readonly IList<WorkItem> _workItems = new List<WorkItem>
        {
            new WorkItem("Validate collection", Priority.High),
            new WorkItem("Health check network", Priority.Low),
            new WorkItem("Ping weather service", Priority.Deferred),
            new WorkItem("Propagate selections", Priority.Medium),
            new WorkItem("Verify communications", Priority.Extreme),
            new WorkItem("Set process state", Priority.Deferred),
            new WorkItem("Enter pooling [contention]", Priority.Medium)
        };

    public WorkItem? ProcessNextHighestPriority()
    {
        WorkItem? workItem =
            _workItems.Where(work => !work.IsCompleted)
                      .OrderByDescending(work => work.Priority)
                      .FirstOrDefault();

        return workItem switch
        {
            not null when _workItems.Remove(workItem) => workItem.MarkAsComplete(),
            _ => default
        };
    }
}
