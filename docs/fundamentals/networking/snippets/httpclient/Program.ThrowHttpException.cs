static partial class Program
{
    static async Task ThrowHttpRequestExceptionAsync(HttpClient httpClient)
    {
        // <throw>
        try
        {
            using var response = await httpClient.GetAsync(
                "https://localhost:5001/doesNotExists");

            // Throw for anything higher than 400.
            if (response is { StatusCode: >= HttpStatusCode.BadRequest })
            {
                throw new HttpRequestException(
                    "Something went wrong", inner: null, response.StatusCode);
            }
        }
        catch (HttpRequestException ex) when (ex is { StatusCode: HttpStatusCode.NotFound })
        {
            Console.WriteLine($"Not found: {ex.Message}");
        }
        // </throw>
    }
}
