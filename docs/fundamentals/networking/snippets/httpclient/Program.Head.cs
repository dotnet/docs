static partial class Program
{
    // <head>
    static async Task HeadAsync(HttpClient client)
    {
        using HttpRequestMessage request = new(
            HttpMethod.Head, 
            "https://www.example.com");

        using HttpResponseMessage response = await client.SendAsync(request);

        response.EnsureSuccessStatusCode();
        response.WriteToConsole();

        WriteLine("{}\n");

        // Expected output:
        //   HEAD https://www.example.com/ HTTP/1.1
        //   {}
    }
    // </head>
}
