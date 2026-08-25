// <ScalabilityWrong>
public static class TimerExampleWrong
{
    public static Task SleepAsync(int millisecondsTimeout)
    {
        return Task.Run(() => Thread.Sleep(millisecondsTimeout));
    }
}
// </ScalabilityWrong>

// <ScalabilityRight>
public static class TimerExampleRight
{
    public static Task SleepAsync(int millisecondsTimeout)
    {
        var tcs = new TaskCompletionSource<bool>();
        var timer = new Timer(
            _ => tcs.TrySetResult(true), null, millisecondsTimeout, Timeout.Infinite);

        tcs.Task.ContinueWith(
            _ => timer.Dispose(), TaskScheduler.Default);

        return tcs.Task;
    }
}
// </ScalabilityRight>

// <OffloadFromUI>
public static class UIOffloadExample
{
    public static int ComputeIntensive(int input)
    {
        int result = 0;
        for (int i = 0; i < input; i++)
        {
            result += i;
        }
        return result;
    }

    public static async Task ConsumeFromUIThreadAsync()
    {
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
