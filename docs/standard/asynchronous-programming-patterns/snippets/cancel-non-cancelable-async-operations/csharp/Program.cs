using System.Net.Sockets;

// <PreferTokenAwareApis>
public static class StreamExamples
{
    public static async Task<int> ReadOnceAsync(
        NetworkStream stream,
        byte[] buffer,
        CancellationToken cancellationToken)
    {
        return await stream.ReadAsync(
            buffer.AsMemory(0, buffer.Length),
            cancellationToken);
    }
}
// </PreferTokenAwareApis>

// <WithCancellation>
public static class TaskCancellationExtensions
{
    public static async Task<T> WithCancellation<T>(
        this Task<T> task,
        CancellationToken cancellationToken)
    {
        if (task.IsCompleted)
            return await task.ConfigureAwait(false);

        var cancellationTaskSource = new TaskCompletionSource<bool>(
            TaskCreationOptions.RunContinuationsAsynchronously);

        using var registration = cancellationToken.Register(
            static state =>
                ((TaskCompletionSource<bool>)state!).TrySetResult(true),
            cancellationTaskSource);

        Task completed = await Task.WhenAny(task, cancellationTaskSource.Task)
            .ConfigureAwait(false);

        if (completed != task)
            throw new OperationCanceledException(cancellationToken);

        return await task.ConfigureAwait(false);
    }
}
// </WithCancellation>

// <CancelBoth>
public static class CancelBothDemo
{
    public static async Task<string> FetchDataAsync(CancellationToken cancellationToken)
    {
        await Task.Delay(500, cancellationToken);
        return "payload";
    }

    public static async Task RunAsync()
    {
        using var cts = new CancellationTokenSource();
        cts.CancelAfter(100);

        try
        {
            string payload = await FetchDataAsync(cts.Token)
                .WithCancellation(cts.Token);
            Console.WriteLine(payload);
        }
        catch (OperationCanceledException)
        {
            Console.WriteLine("Canceled operation and wait.");
        }
    }
}
// </CancelBoth>

// <ObserveLateFault>
public static class ObserveLateFaultDemo
{
    private static async Task<int> FaultLaterAsync()
    {
        await Task.Delay(250);
        throw new InvalidOperationException("Background operation failed.");
    }

    public static async Task RunAsync()
    {
        Task<int> operation = FaultLaterAsync();

        using var cts = new CancellationTokenSource(50);

        try
        {
            await operation.WithCancellation(cts.Token);
        }
        catch (OperationCanceledException)
        {
            Console.WriteLine("Stopped waiting; operation still running.");
        }

        _ = operation.ContinueWith(
            t => Console.WriteLine($"Observed late fault: {t.Exception!.InnerException!.Message}"),
            TaskContinuationOptions.OnlyOnFaulted);

        await Task.Delay(300);
    }
}
// </ObserveLateFault>

public class Program
{
    public static async Task Main()
    {
        Console.WriteLine("=== Cancel both operation and wait ===");
        await CancelBothDemo.RunAsync();

        Console.WriteLine();
        Console.WriteLine("=== Cancel wait only and observe late fault ===");
        await ObserveLateFaultDemo.RunAsync();

        Console.WriteLine();
        Console.WriteLine("Done.");
    }
}
