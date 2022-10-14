static partial class Program
{
    // <cancellation>
    static async Task WithCancellationExtensionsAsync(HttpClient httpClient)
    {
        try
        {
            // The helper method will throw HttpRequestException with StatusCode set if it wasn't 2xx.
            using var stream = await httpClient.GetStreamAsync(
                "https://localhost:5001/doesNotExists");
        }
        catch (HttpRequestException ex) when (ex.StatusCode == HttpStatusCode.NotFound)
        {
            // Handle 404
            Console.WriteLine($"Not found: {ex.Message}");
        }
    }
    // </cancellation>
}
