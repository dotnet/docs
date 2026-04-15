using System.Collections.Concurrent;

// <FireAndForgetPitfall>
public static class FireAndForgetPitfall
{
    public static async Task RunAsync()
    {
        _ = Task.Run(async () =>
        {
            await Task.Delay(100);
            throw new InvalidOperationException("Background operation failed.");
        });

        await Task.Delay(150);
        Console.WriteLine("Caller finished without observing background completion.");
    }
}
// </FireAndForgetPitfall>

public sealed class BackgroundTaskTracker
{
    private readonly ConcurrentDictionary<int, Task> _inFlight = new();

    public void Track(Task operationTask, string name)
    {
        int id = operationTask.Id;
        _inFlight[id] = operationTask;

        _ = operationTask.ContinueWith(completedTask =>
        {
            _inFlight.TryRemove(id, out _);

            if (completedTask.IsFaulted)
            {
                Console.WriteLine($"{name} failed: {completedTask.Exception?.GetBaseException().Message}");
            }
        }, TaskScheduler.Default);
    }

    public Task DrainAsync()
    {
        Task[] snapshot = _inFlight.Values.ToArray();
        return snapshot.Length == 0 ? Task.CompletedTask : Task.WhenAll(snapshot);
    }
}

// <FireAndForgetFix>
public static class FireAndForgetFix
{
    public static async Task RunAsync(BackgroundTaskTracker tracker)
    {
        Task backgroundTask = Task.Run(async () =>
        {
            await Task.Delay(100);
            throw new InvalidOperationException("Background operation failed.");
        });

        tracker.Track(backgroundTask, "Cache refresh");

        try
        {
            await tracker.DrainAsync();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Drain observed failure: {ex.GetBaseException().Message}");
        }
    }
}
// </FireAndForgetFix>

public static class Program
{
    public static async Task Main()
    {
        Console.WriteLine("--- Pitfall ---");
        await FireAndForgetPitfall.RunAsync();

        Console.WriteLine("--- Fix ---");
        var tracker = new BackgroundTaskTracker();
        await FireAndForgetFix.RunAsync(tracker);

        Console.WriteLine("Done.");
    }
}
