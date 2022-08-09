internal static partial class Program
{
    // <getfromjson>
    internal static async Task GetFromJsonAsync(HttpClient client)
    {
        var todo = await client.GetFromJsonAsync<Todo>("todos/2");
        
        Console.WriteLine($"{todo}\n");
    }
    // </getfromjson>
}
