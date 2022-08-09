static partial class Program
{
    // <get>
    static async Task GetAsync(HttpClient client)
    {
        using HttpResponseMessage response =
            await client.GetAsync("todos/3");
        
        response.EnsureSuccessStatusCode();
        response.WriteToConsole();
        
        var jsonResponse = await response.Content.ReadAsStringAsync();
        WriteLine($"{jsonResponse}\n");
    }
    // </get>
}
