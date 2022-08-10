static partial class Program
{
    // <head>
    static async Task HeadAsync(HttpClient client)
    {
        using HttpRequestMessage request = new(
            HttpMethod.Head, 
            "https://www.example.com");

        using HttpResponseMessage response = await client.SendAsync(request);

        response.EnsureSuccessStatusCode()
            .WriteRequestToConsole();

        foreach (var header in response.Headers)
        {
            WriteLine($"{header.Key}: {string.Join(", ", header.Value)}");
        }
        WriteLine();

        // Expected output:
        //   HEAD https://www.example.com/ HTTP/1.1
        //   Accept-Ranges: bytes
        //   Age: 550374
        //   Cache-Control: max-age=604800
        //   Date: Wed, 10 Aug 2022 17:24:55 GMT
        //   ETag: "3147526947"
        //   Server: ECS, (cha / 80E2)
        //   X-Cache: HIT
    }
    // </head>
}
