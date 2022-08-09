static partial class Program
{
    // <delete>
    static async Task DeleteAsync(HttpClient client)
    {
        using HttpResponseMessage response =
            await client.DeleteAsync("todos/1");
        
        response.EnsureSuccessStatusCode();
        response.WriteToConsole();

        var jsonResponse = await response.Content.ReadAsStringAsync();
        WriteLine($"{jsonResponse}\n");
    }
    // </delete>
}
