using System.Diagnostics;

// <SyncExecution>
public static class SyncExecutionExample
{
    public static Task<int> ComputeAsync()
    {
        // No await in this method — it runs entirely synchronously.
        return Task.FromResult(42);
    }
}
// </SyncExecution>

// <OffloadCorrectly>
public static class OffloadExample
{
    public static int ComputeIntensive()
    {
        int sum = 0;
        for (int i = 0; i < 1_000; i++)
            sum += i;
        return sum;
    }

    public static Task<int> ComputeOnThreadPoolAsync()
    {
        return Task.Run(() => ComputeIntensive());
    }
}
// </OffloadCorrectly>

// <AsyncVoid>
public static class AsyncVoidExample
{
    // BAD: async void — can't be awaited.
    public static async void DoWorkBadAsync()
    {
        await Task.Delay(100);
    }

    // GOOD: async Task — callers can await this.
    public static async Task DoWorkGoodAsync()
    {
        await Task.Delay(100);
    }
}
// </AsyncVoid>

// <Deadlock>
public static class DeadlockExample
{
    public static async Task<string> GetDataAsync()
    {
        // Without ConfigureAwait(false), this continuation
        // posts back to the original SynchronizationContext.
        await Task.Delay(100);
        return "data";
    }

    public static void CallerThatDeadlocks()
    {
        // On a single-threaded SynchronizationContext (e.g. UI thread),
        // the following line deadlocks because the continuation needs
        // the same thread that .Result is blocking.
        string result = GetDataAsync().Result;
    }
}
// </Deadlock>

// <DeadlockFix1>
public static class DeadlockFix1
{
    public static async Task CallerFixedAsync()
    {
        // Use await instead of .Result
        string result = await DeadlockExample.GetDataAsync();
        Console.WriteLine(result);
    }
}
// </DeadlockFix1>

// <DeadlockFix2>
public static class DeadlockFix2
{
    public static async Task<string> GetDataSafeAsync()
    {
        await Task.Delay(100).ConfigureAwait(false);
        return "data";
    }
}
// </DeadlockFix2>

// <TaskTaskBug>
public static class TaskTaskBugExample
{
    public static async Task DemoAsync()
    {
        var sw = Stopwatch.StartNew();
        // StartNew returns Task<Task>, not Task.
        // The outer task completes immediately when the lambda yields.
        await Task.Factory.StartNew(async () =>
        {
            await Task.Delay(1000);
        });
        // Elapsed shows ~0 seconds, not ~1 second.
        Console.WriteLine($"Elapsed: {sw.Elapsed.TotalSeconds:F2}s");
    }
}
// </TaskTaskBug>

// <TaskTaskFix1>
public static class TaskTaskFix1
{
    public static async Task DemoAsync()
    {
        var sw = Stopwatch.StartNew();
        await Task.Run(async () =>
        {
            await Task.Delay(1000);
        });
        Console.WriteLine($"Elapsed: {sw.Elapsed.TotalSeconds:F2}s");
    }
}
// </TaskTaskFix1>

// <TaskTaskFix2>
public static class TaskTaskFix2
{
    public static async Task DemoAsync()
    {
        var sw = Stopwatch.StartNew();
        await Task.Factory.StartNew(async () =>
        {
            await Task.Delay(1000);
        }).Unwrap();
        Console.WriteLine($"Elapsed: {sw.Elapsed.TotalSeconds:F2}s");
    }
}
// </TaskTaskFix2>

// <TaskTaskFix3>
public static class TaskTaskFix3
{
    public static async Task DemoAsync()
    {
        var sw = Stopwatch.StartNew();
        Task<Task> outerTask = Task.Factory.StartNew(async () =>
        {
            await Task.Delay(1000);
        });
        Task innerTask = await outerTask;
        await innerTask;
        Console.WriteLine($"Elapsed: {sw.Elapsed.TotalSeconds:F2}s");
    }
}
// </TaskTaskFix3>

// <MissingAwait>
public static class MissingAwaitExample
{
    // BAD: Task.Delay is started but never awaited.
    public static async Task PauseOneSecondBuggyAsync()
    {
        Task.Delay(1000); // CS4014 warning
    }

    // GOOD: await the task.
    public static async Task PauseOneSecondAsync()
    {
        await Task.Delay(1000);
    }
}
// </MissingAwait>

public class Program
{
    public static async Task Main()
    {
        Console.WriteLine("--- SyncExecution demo ---");
        int result1 = await SyncExecutionExample.ComputeAsync();
        Console.WriteLine($"Result: {result1}");

        Console.WriteLine("--- OffloadCorrectly demo ---");
        int result2 = await OffloadExample.ComputeOnThreadPoolAsync();
        Console.WriteLine($"Result: {result2}");

        Console.WriteLine("--- AsyncVoid demo ---");
        await AsyncVoidExample.DoWorkGoodAsync();
        Console.WriteLine("DoWorkGoodAsync completed.");

        Console.WriteLine("--- DeadlockFix1 demo ---");
        await DeadlockFix1.CallerFixedAsync();

        Console.WriteLine("--- DeadlockFix2 demo ---");
        string safe = await DeadlockFix2.GetDataSafeAsync();
        Console.WriteLine($"Safe result: {safe}");

        Console.WriteLine("--- TaskTaskBug demo (outer task only) ---");
        await TaskTaskBugExample.DemoAsync();

        Console.WriteLine("--- TaskTaskFix1 (Task.Run) ---");
        await TaskTaskFix1.DemoAsync();

        Console.WriteLine("--- TaskTaskFix2 (Unwrap) ---");
        await TaskTaskFix2.DemoAsync();

        Console.WriteLine("--- TaskTaskFix3 (double await) ---");
        await TaskTaskFix3.DemoAsync();

        Console.WriteLine("--- MissingAwait demo ---");
        await MissingAwaitExample.PauseOneSecondAsync();
        Console.WriteLine("PauseOneSecondAsync completed.");

        Console.WriteLine("Done.");
    }
}
