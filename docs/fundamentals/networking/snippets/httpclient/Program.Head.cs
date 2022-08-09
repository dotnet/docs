internal static partial class Program
{
    // <head>
    internal static async Task HeadAsync(HttpClient client)
    {
        using HttpRequestMessage request = new(
            HttpMethod.Head, 
            "https://www.example.com");

        using HttpResponseMessage response = await client.SendAsync(request);

        response.EnsureSuccessStatusCode();
        response.WriteToConsole();

        Console.WriteLine("🏁 {}\n");
    }
    // </head>
}
