using System.Text.RegularExpressions;

// <ScalabilityWrong>
public static class TimerExampleWrong
{
    // Don't do this in a library — wrapping a synchronous method with Task.Run
    // doesn't improve scalability. It just shifts which thread is blocked.
    public static Task SleepAsync(int millisecondsTimeout)
    {
        return Task.Run(() => Thread.Sleep(millisecondsTimeout));
    }
}
// </ScalabilityWrong>

// <ScalabilityRight>
public static class TimerExampleRight
{
    // A truly asynchronous implementation consumes no threads while waiting.
    public static Task SleepAsync(int millisecondsTimeout)
    {
        var tcs = new TaskCompletionSource<bool>();
        var timer = new Timer(
            _ => tcs.TrySetResult(true), null, millisecondsTimeout, Timeout.Infinite);

        // Ensure the timer is kept alive until the task completes,
        // then dispose it.
        tcs.Task.ContinueWith(
            _ => timer.Dispose(), TaskScheduler.Default);

        return tcs.Task;
    }
}
// </ScalabilityRight>

// <OffloadFromUI>
public static class UIOffloadExample
{
    // The consumer offloads to a background thread — not the library.
    // This keeps the library simple and lets the caller choose the right approach.
    public static int ComputeIntensive(int input)
    {
        // Simulate CPU-bound work.
        int result = 0;
        for (int i = 0; i < input; i++)
        {
            result += i;
        }
        return result;
    }

    public static async Task ConsumeFromUIThreadAsync()
    {
        // The caller decides to offload, at the right level of granularity.
        int result = await Task.Run(() => ComputeIntensive(10_000));
        Console.WriteLine($"Result: {result}");
    }
}
// </OffloadFromUI>

// Verification entry point
public class Program
{
    public static async Task Main()
    {
        Console.WriteLine("--- ScalabilityRight demo ---");
        await TimerExampleRight.SleepAsync(100);
        Console.WriteLine("SleepAsync completed (100ms).");

        Console.WriteLine("--- OffloadFromUI demo ---");
        await UIOffloadExample.ConsumeFromUIThreadAsync();

        Console.WriteLine("Done.");
    }
}
