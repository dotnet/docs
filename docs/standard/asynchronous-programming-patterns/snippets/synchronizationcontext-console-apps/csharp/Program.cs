using System.Collections.Concurrent;

// Top-level entry point for verification
DefaultBehaviorDemo();
AsyncPumpDemo();
Console.WriteLine("All demos complete.");

// <DefaultBehavior>
static void DefaultBehaviorDemo()
{
    DemoAsync().GetAwaiter().GetResult();
}

static async Task DemoAsync()
{
    var d = new Dictionary<int, int>();
    for (int i = 0; i < 10_000; i++)
    {
        int id = Thread.CurrentThread.ManagedThreadId;
        d[id] = d.TryGetValue(id, out int count) ? count + 1 : 1;

        await Task.Yield();
    }

    foreach (var pair in d)
        Console.WriteLine(pair);
}
// </DefaultBehavior>

// <AsyncPumpDemo>
static void AsyncPumpDemo()
{
    AsyncPump.Run(async () =>
    {
        var d = new Dictionary<int, int>();
        for (int i = 0; i < 10_000; i++)
        {
            int id = Thread.CurrentThread.ManagedThreadId;
            d[id] = d.TryGetValue(id, out int count) ? count + 1 : 1;

            await Task.Yield();
        }

        foreach (var pair in d)
            Console.WriteLine(pair);
    });
}
// </AsyncPumpDemo>

// <SingleThreadContext>
sealed class SingleThreadSynchronizationContext : SynchronizationContext
{
    private readonly
        BlockingCollection<KeyValuePair<SendOrPostCallback, object?>> _queue = new();

    public override void Post(SendOrPostCallback d, object? state)
    {
        _queue.Add(new KeyValuePair<SendOrPostCallback, object?>(d, state));
    }

    public void RunOnCurrentThread()
    {
        while (_queue.TryTake(out KeyValuePair<SendOrPostCallback, object?> workItem,
            Timeout.Infinite))
        {
            workItem.Key(workItem.Value);
        }
    }

    public void Complete() => _queue.CompleteAdding();
}
// </SingleThreadContext>

// <AsyncPumpRun>
static class AsyncPump
{
    public static void Run(Func<Task> func)
    {
        SynchronizationContext? prevCtx = SynchronizationContext.Current;
        try
        {
            var syncCtx = new SingleThreadSynchronizationContext();
            SynchronizationContext.SetSynchronizationContext(syncCtx);

            Task t;
            try
            {
                t = func();
            }
            catch
            {
                syncCtx.Complete();
                throw;
            }

            t.ContinueWith(
                _ => syncCtx.Complete(), TaskScheduler.Default);

            syncCtx.RunOnCurrentThread();

            t.GetAwaiter().GetResult();
        }
        finally
        {
            SynchronizationContext.SetSynchronizationContext(prevCtx);
        }
    }
    // </AsyncPumpRun>

    // <AsyncVoidSupport>
    public static void Run(Action asyncMethod)
    {
        SynchronizationContext? prevCtx = SynchronizationContext.Current;
        try
        {
            var syncCtx = new AsyncVoidSynchronizationContext();
            SynchronizationContext.SetSynchronizationContext(syncCtx);

            Exception? caughtException = null;

            syncCtx.OperationStarted();
            try
            {
                asyncMethod();
            }
            catch (Exception ex)
            {
                caughtException = ex;
                syncCtx.Complete();
            }
            finally
            {
                syncCtx.OperationCompleted();
            }

            syncCtx.RunOnCurrentThread();

            if (caughtException is not null)
            {
                System.Runtime.ExceptionServices.ExceptionDispatchInfo.Capture(caughtException).Throw();
            }
        }
        finally
        {
            SynchronizationContext.SetSynchronizationContext(prevCtx);
        }
    }
}

sealed class AsyncVoidSynchronizationContext : SynchronizationContext
{
    private readonly
        BlockingCollection<KeyValuePair<SendOrPostCallback, object?>> _queue = new();
    private int _operationCount;

    public override void Post(SendOrPostCallback d, object? state)
    {
        _queue.Add(new KeyValuePair<SendOrPostCallback, object?>(d, state));
    }

    public override void OperationStarted() =>
        Interlocked.Increment(ref _operationCount);

    public override void OperationCompleted()
    {
        if (Interlocked.Decrement(ref _operationCount) == 0)
            Complete();
    }

    public void RunOnCurrentThread()
    {
        while (_queue.TryTake(out KeyValuePair<SendOrPostCallback, object?> workItem,
            Timeout.Infinite))
        {
            workItem.Key(workItem.Value);
        }
    }

    public void Complete() => _queue.CompleteAdding();
}
// </AsyncVoidSupport>
