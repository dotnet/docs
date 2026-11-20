using System.Threading;

// <MissingSetExceptionBug>
// ⚠️ DON'T copy this snippet. It demonstrates a problem that causes hangs.
public sealed class MissingSetExceptionBug
{
    public Task<string> StartAsync(bool fail)
    {
        var tcs = new TaskCompletionSource<string>(TaskCreationOptions.RunContinuationsAsynchronously);

        try
        {
            if (fail)
            {
                throw new InvalidOperationException("Simulated failure");
            }

            tcs.SetResult("success");
        }
        catch (Exception)
        {
            // BUG: forgot SetException or TrySetException.
        }

        return tcs.Task;
    }
}
// </MissingSetExceptionBug>

// <MissingSetExceptionFix>
public sealed class MissingSetExceptionFix
{
    public Task<string> StartAsync(bool fail)
    {
        var tcs = new TaskCompletionSource<string>(TaskCreationOptions.RunContinuationsAsynchronously);

        try
        {
            if (fail)
            {
                throw new InvalidOperationException("Simulated failure");
            }

            tcs.TrySetResult("success");
        }
        catch (Exception ex)
        {
            tcs.TrySetException(ex);
        }

        return tcs.Task;
    }
}
// </MissingSetExceptionFix>

// <TrySetRace>
public static class TrySetRaceExample
{
    public static void ShowRaceSafeCompletion()
    {
        var tcs = new TaskCompletionSource<int>(TaskCreationOptions.RunContinuationsAsynchronously);

        bool first = tcs.TrySetResult(42);
        bool second = tcs.TrySetException(new TimeoutException("Too late"));

        Console.WriteLine($"First completion won: {first}");
        Console.WriteLine($"Second completion accepted: {second}");
        Console.WriteLine($"Result: {tcs.Task.Result}");
    }
}
// </TrySetRace>

// <ResetBug>
// ⚠️ DON'T copy this snippet. It demonstrates a problem where old waiters never complete.
public sealed class ResetBug
{
    private TaskCompletionSource<bool> _signal = NewSignal();

    public Task WaitAsync() => _signal.Task;

    public void Reset()
    {
        // BUG: waiters on the old task might never complete.
        _signal = NewSignal();
    }

    public void Pulse()
    {
        _signal.TrySetResult(true);
    }

    private static TaskCompletionSource<bool> NewSignal() =>
        new(TaskCreationOptions.RunContinuationsAsynchronously);
}
// </ResetBug>

// <ResetFix>
public sealed class ResetFix
{
    private TaskCompletionSource<bool> _signal = NewSignal();

    public Task WaitAsync() => _signal.Task;

    public void Reset()
    {
        TaskCompletionSource<bool> previous = Interlocked.Exchange(ref _signal, NewSignal());
        previous.TrySetCanceled();
    }

    public void Pulse()
    {
        _signal.TrySetResult(true);
    }

    private static TaskCompletionSource<bool> NewSignal() =>
        new(TaskCreationOptions.RunContinuationsAsynchronously);
}
// </ResetFix>

public static class Program
{
    public static void Main()
    {
        Console.WriteLine("--- MissingSetExceptionBug ---");
        var buggy = new MissingSetExceptionBug();
        Task<string> buggyTask = buggy.StartAsync(fail: true);
        bool completed = buggyTask.Wait(200);
        Console.WriteLine($"Task completed: {completed}");

        Console.WriteLine("--- MissingSetExceptionFix ---");
        var fixedVersion = new MissingSetExceptionFix();
        Task<string> fixedTask = fixedVersion.StartAsync(fail: true);
        try
        {
            fixedTask.GetAwaiter().GetResult();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Observed failure: {ex.GetType().Name}");
        }

        Console.WriteLine("--- TrySetRace ---");
        TrySetRaceExample.ShowRaceSafeCompletion();

        Console.WriteLine("--- ResetBug ---");
        var resetBug = new ResetBug();
        Task oldWaiter = resetBug.WaitAsync();
        resetBug.Reset();
        resetBug.Pulse();
        Console.WriteLine($"Original waiter completed: {oldWaiter.Wait(200)}");

        Console.WriteLine("--- ResetFix ---");
        var resetFix = new ResetFix();
        Task oldWaiterFixed = resetFix.WaitAsync();
        resetFix.Reset();
        resetFix.Pulse();
        try
        {
            oldWaiterFixed.GetAwaiter().GetResult();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Original waiter completed with: {ex.GetType().Name}");
        }
    }
}
