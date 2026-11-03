using System.Collections.Concurrent;

// Verification entry point
ExecutionContextCaptureDemo();
await TaskRunExample.ProcessOnUIThread();

// Install a custom SynchronizationContext for the demo
var demoContext = new DemoSynchronizationContext();
SynchronizationContext.SetSynchronizationContext(demoContext);
SyncContextExample.DoWork();
demoContext.ProcessQueue();
SynchronizationContext.SetSynchronizationContext(null);

await Task.Delay(200);
Console.WriteLine("Done.");

// <ExecutionContextCapture>
static void ExecutionContextCaptureDemo()
{
    // Capture the current ExecutionContext
    ExecutionContext? ec = ExecutionContext.Capture();

    // Later, run a delegate within that captured context
    if (ec is not null)
    {
        ExecutionContext.Run(ec, _ =>
        {
            // Code here sees the ambient state from the point of capture
            Console.WriteLine("Running inside captured ExecutionContext.");
        }, null);
    }
}
// </ExecutionContextCapture>

static class SingleThreadSynchronizationContext
{
    public static Task Run(Func<Task> asyncAction)
    {
        var previousContext = SynchronizationContext.Current;
        var context = new SingleThreadContext();
        SynchronizationContext.SetSynchronizationContext(context);

        Task task;
        try
        {
            task = asyncAction();
            task.ContinueWith(_ => context.Complete(), TaskScheduler.Default);
            context.RunOnCurrentThread();
            return task;
        }
        finally
        {
            SynchronizationContext.SetSynchronizationContext(previousContext);
        }
    }

    private sealed class SingleThreadContext : SynchronizationContext
    {
        private readonly BlockingCollection<(SendOrPostCallback Callback, object? State)> _queue = new();

        public override void Post(SendOrPostCallback d, object? state) => _queue.Add((d, state));

        public void RunOnCurrentThread()
        {
            foreach (var workItem in _queue.GetConsumingEnumerable())
            {
                workItem.Callback(workItem.State);
            }
        }

        public void Complete() => _queue.CompleteAdding();
    }
}

// <SyncContextUsage>
static class SyncContextExample
{
    public static void DoWork()
    {
        // Capture the current SynchronizationContext
        SynchronizationContext? sc = SynchronizationContext.Current;

        ThreadPool.QueueUserWorkItem(_ =>
        {
            // ... do work on the ThreadPool ...

            if (sc is not null)
            {
                sc.Post(_ =>
                {
                    // This runs on the original context (e.g. UI thread)
                    Console.WriteLine("Back on the original context.");
                }, null);
            }
        });
    }
}
// </SyncContextUsage>

// Minimal SynchronizationContext for demo purposes
sealed class DemoSynchronizationContext : SynchronizationContext
{
    private readonly BlockingCollection<(SendOrPostCallback, object?)> _queue = new();

    public override void Post(SendOrPostCallback d, object? state)
    {
        _queue.Add((d, state));
    }

    public void ProcessQueue()
    {
        var (callback, state) = _queue.Take();
        callback(state);

        while (_queue.TryTake(out var workItem))
        {
            workItem.Item1(workItem.Item2);
        }
    }
}

// <TaskRunExample>
static class TaskRunExample
{
    public static async Task ProcessOnUIThread()
    {
        // This method is called from a thread with a SynchronizationContext.
        // Task.Run offloads work to the thread pool.
        string result = await Task.Run(async () =>
        {
            string data = await DownloadAsync();
            // Compute runs on the thread pool, not the original context,
            // because SynchronizationContext doesn't flow into Task.Run.
            return Compute(data);
        });

        // Back on the original context (the continuation is posted back).
        Console.WriteLine(result);
    }

    private static async Task<string> DownloadAsync()
    {
        await Task.Delay(100);
        return "downloaded data";
    }

    private static string Compute(string data) =>
        $"Computed: {data.Length} chars";
}
// </TaskRunExample>
