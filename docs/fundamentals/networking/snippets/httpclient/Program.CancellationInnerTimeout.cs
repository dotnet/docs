﻿static partial class Program
{
    static async Task WithCancellationAndInnerTimeoutAsync(HttpClient httpClient)
    {
        // <innertimeout>
        try
        {
            // Assuming:
            //   httpClient.Timeout = TimeSpan.FromSeconds(10)

            using var response = await httpClient.GetAsync(
                "http://localhost:5001/sleepFor?seconds=100");
        }
        catch (OperationCanceledException ex) when (ex.InnerException is TimeoutException tex)
        {
            Console.WriteLine($"Timed out: {ex.Message}, {tex.Message}");
        }
        // </innertimeout>
    }
}
