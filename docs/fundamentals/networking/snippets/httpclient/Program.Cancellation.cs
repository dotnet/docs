static partial class Program
{
    // <cancellation>
    static async Task WithCancellationAsync(HttpClient httpClient)
    {
        var cts = new CancellationTokenSource();
        try
        {
            // Assuming:
            //   client.Timeout = TimeSpan.FromSeconds(10)

            using var response = await httpClient.GetAsync(
                "http://localhost:5001/sleepFor?seconds=100", cts.Token);
        }
        catch (TaskCanceledException ex) when (cts.IsCancellationRequested)
        {
            // When the token has been canceled, it is not a timeout.
            WriteLine($"Canceled: {ex.Message}");
        }
        catch (TaskCanceledException ex)
        {
            WriteLine($"Timed out: {ex.Message}");
        }
    }
    // </cancellation>
}
