static partial class Program
{
    // <trace>
    static async Task TraceAsync(HttpClient client)
    {
        using HttpRequestMessage request = new(
            HttpMethod.Trace, 
            "http://www.example.com");

        using HttpResponseMessage response =
            await client.SendAsync(request);

        response.EnsureSuccessStatusCode();
        response.WriteToConsole();

        WriteLine("{}\n");
    }
    // </trace>
}
