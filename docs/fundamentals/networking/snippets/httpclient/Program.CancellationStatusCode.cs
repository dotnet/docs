static partial class Program
{
    static async Task WithCancellationAndStatusCodeAsync(HttpClient httpClient)
    {
        // <statuscode>
        try
        {
            // Assuming:
            //   httpClient.Timeout = TimeSpan.FromSeconds(10)

            using var response = await httpClient.GetAsync(
                "http://localhost:5001/doesNotExist");

            response.EnsureSuccessStatusCode();
        }
        catch (HttpRequestException ex) when (ex is { StatusCode: HttpStatusCode.NotFound })
        {
            // Handle 404
            Console.WriteLine($"Not found: {ex.Message}");
        }
        // </statuscode>
    }
}
