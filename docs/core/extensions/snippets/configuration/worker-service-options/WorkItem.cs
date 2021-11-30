namespace WorkerServiceOptions.Example;

public record WorkItem(
    string Name, Priority Priority, bool IsCompleted = false)
{
    public Guid Id { get; init; } = Guid.NewGuid();

    public WorkItem MarkAsComplete() =>
        this with { IsCompleted = true };

    public override string ToString() =>
        $"Priority-{Priority} ({Id}): '{Name}'";
}
