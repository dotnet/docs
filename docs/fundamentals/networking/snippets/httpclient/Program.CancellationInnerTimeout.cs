static partial class Program
{
    // <cancellation>
    static async Task WithCancellationAndInnerTimeoutAsync(HttpClient httpClient)
    {
        try
        {
            // Assuming:
            //   client.Timeout = TimeSpan.FromSeconds(10)

            using var response = await httpClient.GetAsync(
                "http://localhost:5001/sleepFor?seconds=100");
        }
        catch (TaskCanceledException ex) when (ex.InnerException is TimeoutException)
        {
            // When the token has been canceled, it is not a timeout.
            WriteLine($"Timed out: {ex.Message}");
        }
        catch (TaskCanceledException ex)
        {
            WriteLine($"Canceled: {ex.Message}");
        }
    }
    // </cancellation>
}
