// <SingleException>
public static class SingleExceptionExample
{
    public static Task<int> FaultAsync()
    {
        return Task.FromException<int>(new InvalidOperationException("Single failure"));
    }

    public static void ShowBlockingDifferences()
    {
        try
        {
            _ = FaultAsync().GetAwaiter().GetResult();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"GetAwaiter().GetResult() threw {ex.GetType().Name}");
        }
    }
}
// </SingleException>

// <SingleExceptionBad>
// ⚠️ DON'T copy this snippet. It demonstrates a problem where exceptions get wrapped unnecessarily.
public static class SingleExceptionBadExample
{
    public static Task<int> FaultAsync()
    {
        return Task.FromException<int>(new InvalidOperationException("Single failure"));
    }

    public static void ShowBlockingDifferences()
    {
        try
        {
            _ = FaultAsync().Result;
        }
        catch (AggregateException ex)
        {
            Console.WriteLine($".Result threw {ex.GetType().Name} with inner {ex.InnerException?.GetType().Name}");
        }
    }
}
// </SingleExceptionBad>

// <MultiException>
public static class MultiExceptionExample
{
    public static async Task FaultAfterDelayAsync(string name, int milliseconds)
    {
        await Task.Delay(milliseconds);
        throw new InvalidOperationException($"{name} failed");
    }

    public static void ShowMultipleExceptions()
    {
        Task combined = Task.WhenAll(
            FaultAfterDelayAsync("First", 10),
            FaultAfterDelayAsync("Second", 20));

        try
        {
            combined.GetAwaiter().GetResult();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"GetAwaiter().GetResult() surfaced: {ex.Message}");
        }

        if (combined.IsFaulted && combined.Exception is not null)
        {
            AggregateException allErrors = combined.Exception.Flatten();
            Console.WriteLine($"Task.Exception contains {allErrors.InnerExceptions.Count} exceptions.");
        }
        else
        {
            Console.WriteLine("Task.Exception is null because the task didn't fault.");
        }
    }
}
// </MultiException>

// <UnobservedTaskException>
public static class UnobservedTaskExceptionExample
{
    public static void ShowEventBehavior()
    {
        bool eventRaised = false;

        TaskScheduler.UnobservedTaskException += (_, args) =>
        {
            eventRaised = true;
            Console.WriteLine($"UnobservedTaskException raised with {args.Exception.InnerExceptions.Count} exception(s).");
            args.SetObserved();
        };

        _ = Task.Run(() => throw new ApplicationException("Background failure"));

        GC.Collect();
        GC.WaitForPendingFinalizers();
        GC.Collect();

        Console.WriteLine(eventRaised
            ? "Event was raised. The process continued."
            : "Event was not observed in this short run. The process still continued.");
    }
}
// </UnobservedTaskException>

public static class Program
{
    public static void Main()
    {
        Console.WriteLine("--- SingleException ---");
        SingleExceptionExample.ShowBlockingDifferences();

        Console.WriteLine("--- SingleExceptionBad ---");
        SingleExceptionBadExample.ShowBlockingDifferences();

        Console.WriteLine("--- MultiException ---");
        MultiExceptionExample.ShowMultipleExceptions();

        Console.WriteLine("--- UnobservedTaskException ---");
        UnobservedTaskExceptionExample.ShowEventBehavior();
    }
}
