static partial class Program
{
    // <sharedclient>
    // HttpClient lifecycle management best practices:
    // https://learn.microsoft.com/dotnet/fundamentals/networking/http/httpclient-guidelines#recommended-use
    private static HttpClient sharedClient = new()
    {
        BaseAddress = new Uri("https://jsonplaceholder.typicode.com"),
    };
    // </sharedclient>
    public static async Task Main(string[] args)
    {
        await GetAsync(sharedClient);
        await GetFromJsonAsync(sharedClient);
        await PostAsync(sharedClient);
        await PostAsJsonAsync(sharedClient);
        await PutAsync(sharedClient);
        await PutAsJsonAsync(sharedClient);
        await PatchAsync(sharedClient);
        await DeleteAsync(sharedClient);

        // <client>
        using HttpClient httpClient = new();
        // </client>

        await HeadAsync(httpClient);
        await OptionsAsync(httpClient);
    }
}
