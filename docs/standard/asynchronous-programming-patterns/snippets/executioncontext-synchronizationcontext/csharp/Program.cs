// Verification entry point
await SingleThreadSynchronizationContext.Run(async () =>
{
    ExecutionContextCaptureDemo();
    await TaskRunExample.ProcessOnUIThread();
    SyncContextExample.DoWork();
    await Task.Delay(200);
    Console.WriteLine("Done.");
});

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

// <TaskRunExample>
static class TaskRunExample
{
    public static async Task ProcessOnUIThread()
    {
        // Assume this method is called from a UI thread.
        // Task.Run offloads work to the thread pool.
        string result = await Task.Run(async () =>
        {
            string data = await DownloadAsync();
            // Compute runs on the thread pool, not the UI thread,
            // because SynchronizationContext doesn't flow into Task.Run.
            return Compute(data);
        });

        // Back on the UI thread (captured by the outer await).
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
