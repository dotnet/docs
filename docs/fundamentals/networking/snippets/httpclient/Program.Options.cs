static partial class Program
{
    // <options>
    static async Task OptionsAsync(HttpClient client)
    {
        using HttpRequestMessage request = new(
            HttpMethod.Options, 
            "https://www.example.com");

        using HttpResponseMessage response = await client.SendAsync(request);

        response.EnsureSuccessStatusCode();
        response.WriteToConsole();
        
        if (response.Content.Headers.Allow is { Count: > 0 } allowHeaders)
        {
            WriteLine(
                $"Allow: {string.Join(", ", allowHeaders)}\n");
        }
    }
    // </options>
}
