using System.Diagnostics;

// <ActionPitfall>
public static class TimingHelper
{
    public static double Time(Action action, int iterations = 10)
    {
        var sw = Stopwatch.StartNew();
        for (int i = 0; i < iterations; i++)
            action();
        return sw.Elapsed.TotalSeconds / iterations;
    }
}

public static class ActionPitfallDemo
{
    public static void Run()
    {
        // Synchronous lambda — timing is accurate.
        double syncSeconds = TimingHelper.Time(() =>
        {
            Thread.Sleep(100);
        }, iterations: 3);
        Console.WriteLine($"Sync: {syncSeconds:F4}s per iteration");

        // Async lambda — becomes async void, returns immediately.
        double asyncSeconds = TimingHelper.Time(async () =>
        {
            await Task.Delay(100);
        }, iterations: 3);
        Console.WriteLine($"Async (buggy): {asyncSeconds:F4}s per iteration");
    }
}
// </ActionPitfall>

// <ActionFix>
public static class TimingHelperFixed
{
    public static double Time(Action action, int iterations = 10)
    {
        var sw = Stopwatch.StartNew();
        for (int i = 0; i < iterations; i++)
            action();
        return sw.Elapsed.TotalSeconds / iterations;
    }

    public static async Task<double> TimeAsync(Func<Task> func, int iterations = 10)
    {
        var sw = Stopwatch.StartNew();
        for (int i = 0; i < iterations; i++)
            await func();
        return sw.Elapsed.TotalSeconds / iterations;
    }
}

public static class ActionFixDemo
{
    public static async Task Run()
    {
        // Now the async lambda maps to Func<Task>, and
        // the timer awaits each iteration to complete.
        double seconds = await TimingHelperFixed.TimeAsync(async () =>
        {
            await Task.Delay(100);
        }, iterations: 3);
        Console.WriteLine($"Async (fixed): {seconds:F4}s per iteration");
    }
}
// </ActionFix>

// <ParallelForEachBug>
public static class ParallelForEachBugDemo
{
    public static void Run()
    {
        var sw = Stopwatch.StartNew();
        Parallel.ForEach(Enumerable.Range(0, 10), async i =>
        {
            await Task.Delay(200);
        });
        // Completes almost immediately — the async lambdas are fire-and-forget.
        Console.WriteLine($"Parallel.ForEach (buggy): {sw.Elapsed.TotalSeconds:F2}s");
    }
}
// </ParallelForEachBug>

// <ParallelForEachFix>
public static class ParallelForEachFixDemo
{
    public static async Task RunAsync()
    {
        var sw = Stopwatch.StartNew();
        await Parallel.ForEachAsync(
            Enumerable.Range(0, 10),
            new ParallelOptions { MaxDegreeOfParallelism = 4 },
            async (i, ct) =>
            {
                await Task.Delay(200, ct);
            });
        Console.WriteLine($"Parallel.ForEachAsync (fixed): {sw.Elapsed.TotalSeconds:F2}s");
    }
}
// </ParallelForEachFix>

// <WhenAllAlternative>
public static class WhenAllAlternativeDemo
{
    public static async Task RunAsync()
    {
        var sw = Stopwatch.StartNew();
        var tasks = Enumerable.Range(0, 10)
            .Select(async i =>
            {
                await Task.Delay(200);
            });
        await Task.WhenAll(tasks);
        Console.WriteLine($"Task.WhenAll: {sw.Elapsed.TotalSeconds:F2}s");
    }
}
// </WhenAllAlternative>

// <StartNewBug>
public static class StartNewBugDemo
{
    public static async Task RunAsync()
    {
        var sw = Stopwatch.StartNew();
        // t is Task<Task> — the outer task completes at the first yielding await.
        Task<Task> t = Task.Factory.StartNew(async () =>
        {
            await Task.Delay(1000);
        });
        await t; // Awaits only the outer task.
        Console.WriteLine($"StartNew (buggy): {sw.Elapsed.TotalSeconds:F2}s");
    }
}
// </StartNewBug>

// <StartNewFix1>
public static class StartNewFix1Demo
{
    public static async Task RunAsync()
    {
        var sw = Stopwatch.StartNew();
        await Task.Run(async () =>
        {
            await Task.Delay(1000);
        });
        Console.WriteLine($"Task.Run (fixed): {sw.Elapsed.TotalSeconds:F2}s");
    }
}
// </StartNewFix1>

// <StartNewFix2>
public static class StartNewFix2Demo
{
    public static async Task RunAsync()
    {
        var sw = Stopwatch.StartNew();
        await Task.Factory.StartNew(async () =>
        {
            await Task.Delay(1000);
        }).Unwrap();
        Console.WriteLine($"StartNew + Unwrap (fixed): {sw.Elapsed.TotalSeconds:F2}s");
    }
}
// </StartNewFix2>

public class Program
{
    public static async Task Main()
    {
        Console.WriteLine("=== Action pitfall ===");
        ActionPitfallDemo.Run();

        Console.WriteLine();
        Console.WriteLine("=== Action fix ===");
        ActionFixDemo.Run();

        Console.WriteLine();
        Console.WriteLine("=== Parallel.ForEach bug ===");
        ParallelForEachBugDemo.Run();

        Console.WriteLine();
        Console.WriteLine("=== Parallel.ForEachAsync fix ===");
        await ParallelForEachFixDemo.RunAsync();

        Console.WriteLine();
        Console.WriteLine("=== Task.WhenAll alternative ===");
        await WhenAllAlternativeDemo.RunAsync();

        Console.WriteLine();
        Console.WriteLine("=== StartNew bug ===");
        await StartNewBugDemo.RunAsync();

        Console.WriteLine();
        Console.WriteLine("=== Task.Run fix ===");
        await StartNewFix1Demo.RunAsync();

        Console.WriteLine();
        Console.WriteLine("=== StartNew + Unwrap fix ===");
        await StartNewFix2Demo.RunAsync();

        Console.WriteLine();
        Console.WriteLine("Done.");
    }
}
