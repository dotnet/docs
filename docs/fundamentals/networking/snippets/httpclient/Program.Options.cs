static partial class Program
{
    // <options>
    static async Task OptionsAsync(HttpClient client)
    {
        using HttpRequestMessage request = new(
            HttpMethod.Options, 
            "https://www.example.com");

        using HttpResponseMessage response = await client.SendAsync(request);

        response.EnsureSuccessStatusCode()
            .WriteRequestToConsole();
        
        if (response.Content.Headers.Allow is { Count: > 0 } allowHeaders)
        {
            WriteLine(
                $"Allow: {string.Join(", ", allowHeaders)}\n");
        }

        // Expected output
        //   OPTIONS https://www.example.com/ HTTP/1.1
        //   Allow: OPTIONS, GET, HEAD, POST
    }
    // </options>
}
