// <LinkedTokenBasic>
public static class LinkedTokenBasicDemo
{
    public static async Task RunAsync(CancellationToken userToken)
    {
        using var timeoutCts = new CancellationTokenSource(TimeSpan.FromMilliseconds(150));
        using var linkedCts = CancellationTokenSource.CreateLinkedTokenSource(
            userToken,
            timeoutCts.Token);

        await Task.Delay(500, linkedCts.Token);
    }
}
// </LinkedTokenBasic>

// <LinkedTokenHelper>
public static class TimeoutPolicy
{
    public static async Task ExecuteWithLinkedTimeoutAsync(
        Func<CancellationToken, Task> operation,
        TimeSpan timeout,
        CancellationToken userToken)
    {
        using var timeoutCts = new CancellationTokenSource(timeout);
        using var linkedCts = CancellationTokenSource.CreateLinkedTokenSource(
            userToken,
            timeoutCts.Token);

        await operation(linkedCts.Token);
    }
}
// </LinkedTokenHelper>

// <WaitAsyncAlternative>
public static class WaitOnlyTimeoutDemo
{
    public static async Task RunAsync(CancellationToken userToken)
    {
        Task operation = Task.Delay(500);

        try
        {
            await operation.WaitAsync(TimeSpan.FromMilliseconds(100), userToken);
            Console.WriteLine("Operation completed before timeout.");
        }
        catch (TimeoutException)
        {
            Console.WriteLine("Timed out waiting without canceling operation.");
        }
        catch (OperationCanceledException)
        {
            Console.WriteLine("Canceled while waiting for the operation.");
        }
    }
}
// </WaitAsyncAlternative>

public class Program
{
    public static async Task Main()
    {
        Console.WriteLine("=== Linked token basic ===");
        using (var userCts = new CancellationTokenSource())
        {
            try
            {
                await LinkedTokenBasicDemo.RunAsync(userCts.Token);
            }
            catch (OperationCanceledException)
            {
                Console.WriteLine("Canceled by timeout or caller token.");
            }
        }

        Console.WriteLine();
        Console.WriteLine("=== Linked token helper ===");
        using (var userCts = new CancellationTokenSource())
        {
            try
            {
                await TimeoutPolicy.ExecuteWithLinkedTimeoutAsync(
                    async token =>
                    {
                        await Task.Delay(500, token);
                    },
                    TimeSpan.FromMilliseconds(120),
                    userCts.Token);
            }
            catch (OperationCanceledException)
            {
                Console.WriteLine("Helper canceled operation as expected.");
            }
        }

        Console.WriteLine();
        Console.WriteLine("=== WaitAsync alternative ===");
        using (var userCts = new CancellationTokenSource())
        {
            await WaitOnlyTimeoutDemo.RunAsync(userCts.Token);
        }

        Console.WriteLine();
        Console.WriteLine("Done.");
    }
}
