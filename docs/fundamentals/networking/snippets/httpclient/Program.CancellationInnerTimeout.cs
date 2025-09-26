static partial class Program
{
    static async Task WithCancellationAndInnerTimeoutAsync(HttpClient httpClient)
    {
        // <innertimeout>
        using var cts = new CancellationTokenSource();
        try
        {
            // Assuming:
            //   httpClient.Timeout = TimeSpan.FromSeconds(10)

            using var response = await httpClient.GetAsync(
                "http://localhost:5001/sleepFor?seconds=100", cts.Token);
        }
        catch (OperationCanceledException ex) when (ex.InnerException is TimeoutException tex)
        {
            // when the time-out occurred. Here the cancellation token has not been canceled.
            Console.WriteLine($"Timed out: {ex.Message}, {tex.Message}");
        }
        // </innertimeout>
    }
}
