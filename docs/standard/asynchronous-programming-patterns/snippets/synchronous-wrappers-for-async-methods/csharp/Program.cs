// <SyncOverAsyncAPM>
public class ApmWrapper
{
    // Wrapping an APM implementation with a synchronous method.
    // EndFoo blocks until the async operation completes.
    public static int Foo(Func<AsyncCallback?, object?, IAsyncResult> beginFoo,
                          Func<IAsyncResult, int> endFoo)
    {
        IAsyncResult ar = beginFoo(null, null);
        return endFoo(ar);
    }
}
// </SyncOverAsyncAPM>

// <SyncOverAsyncTAP>
public class TapWrapper
{
    // Wrapping a TAP method with a synchronous method.
    // Accessing .Result blocks until the task completes.
    public static int Foo(Func<Task<int>> fooAsync)
    {
        return fooAsync().Result;
    }
}
// </SyncOverAsyncTAP>

// <DeadlockExample>
public static class DeadlockExample
{
    // This method deadlocks when called from a UI thread
    // or any thread with a single-threaded SynchronizationContext.
    private static void Delay(int milliseconds)
    {
        DelayAsync(milliseconds).Wait();
    }

    private static async Task DelayAsync(int milliseconds)
    {
        await Task.Delay(milliseconds);
        // When there's a SynchronizationContext, the continuation
        // tries to post back to the calling thread — but that thread
        // is blocked in .Wait() above. Deadlock!
    }
}
// </DeadlockExample>

// <ThreadPoolDeadlock>
public static class ThreadPoolDeadlockExample
{
    // When FooAsync depends on the thread pool to complete its internal work,
    // blocking all pool threads with synchronous wrappers causes deadlock.
    public static int Foo(Func<Task<int>> fooAsync)
    {
        return fooAsync().Result;
    }

    public static async Task DemonstrateDeadlockRiskAsync()
    {
        // If the thread pool maximum is low (e.g., 25 threads) and all threads
        // call Foo simultaneously, the async I/O completions can't run
        // because no threads are available — all are blocked in .Result.
        var tasks = Enumerable.Range(0, 25)
            .Select(_ => Task.Run(() => Foo(() => SomeIOOperationAsync())));
        await Task.WhenAll(tasks);
    }

    private static async Task<int> SomeIOOperationAsync()
    {
        await Task.Delay(100);
        return 42;
    }
}
// </ThreadPoolDeadlock>

// <ConfigureAwaitMitigation>
public static class ConfigureAwaitMitigation
{
    // If you must wrap sync over async, ensure the async implementation
    // uses ConfigureAwait(false) on all awaits to avoid marshaling
    // back to the calling context.
    public static async Task<int> LibraryMethodAsync()
    {
        await Task.Delay(100).ConfigureAwait(false);
        return 42;
    }

    // The consumer offloads to the thread pool, ensuring there's no
    // SynchronizationContext that could cause a deadlock.
    public static int Sync()
    {
        return Task.Run(() => LibraryMethodAsync()).Result;
    }
}
// </ConfigureAwaitMitigation>

// Verification entry point
public class Program
{
    public static async Task Main()
    {
        Console.WriteLine("--- ConfigureAwait mitigation demo ---");
        int result = ConfigureAwaitMitigation.Sync();
        Console.WriteLine($"Result: {result}");

        Console.WriteLine("Done.");
    }
}
