static partial class Program
{
    // <options>
    static async Task OptionsAsync(HttpClient httpClient)
    {
        using HttpRequestMessage request = new(
            HttpMethod.Options, 
            "https://www.example.com");

        using HttpResponseMessage response = await httpClient.SendAsync(request);

        response.EnsureSuccessStatusCode()
            .WriteRequestToConsole();

        foreach (var header in response.Content.Headers)
        {
            Console.WriteLine($"{header.Key}: {string.Join(", ", header.Value)}");
        }
        Console.WriteLine();

        // Expected output
        //   OPTIONS https://www.example.com/ HTTP/1.1
        //   Allow: OPTIONS, GET, HEAD, POST
        //   Content-Type: text/html; charset=utf-8
        //   Expires: Wed, 17 Aug 2022 17:28:42 GMT
        //   Content-Length: 0
    }
    // </options>
}
