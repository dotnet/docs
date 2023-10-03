static partial class Program
{
    static async Task WithCancellationAsync(HttpClient httpClient)
    {
        // <cancellation>
        using var cts = new CancellationTokenSource();
        try
        {
            // Assuming:
            //   httpClient.Timeout = TimeSpan.FromSeconds(10)

            using var response = await httpClient.GetAsync(
                "http://localhost:5001/sleepFor?seconds=100", cts.Token);
        }
        catch (OperationCanceledException ex) when (cts.IsCancellationRequested)
        {
            // When the token has been canceled, it is not a timeout.
            Console.WriteLine($"Canceled: {ex.Message}");
        }
        // </cancellation>
    }
}
