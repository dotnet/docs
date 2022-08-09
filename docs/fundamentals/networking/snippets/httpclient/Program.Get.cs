internal static partial class Program
{
    // <get>
    internal static async Task GetAsync(HttpClient client)
    {
        using HttpResponseMessage response =
            await client.GetAsync("todos?userId=1&completed=false");
        
        response.EnsureSuccessStatusCode();
        response.WriteToConsole();
        
        var jsonResponse = await response.Content.ReadAsStringAsync();
        
        Console.WriteLine($"🏁 {jsonResponse}\n");
    }
    // </get>
}
