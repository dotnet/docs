static partial class Program
{
    static async Task WithCancellationExtensionsAsync(HttpClient httpClient)
    {
        // <helpers>
        try
        {
            // These extension methods will throw HttpRequestException
            // with StatusCode set when the HTTP request status code isn't 2xx:
            //
            //   GetByteArrayAsync
            //   GetStreamAsync
            //   GetStringAsync

            using var stream = await httpClient.GetStreamAsync(
                "https://localhost:5001/doesNotExists");
        }
        catch (HttpRequestException ex) when (ex is { StatusCode: HttpStatusCode.NotFound })
        {
            // Handle 404
            Console.WriteLine($"Not found: {ex.Message}");
        }
        // </helpers>
    }
}
