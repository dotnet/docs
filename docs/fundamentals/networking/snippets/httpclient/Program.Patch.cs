internal static partial class Program
{
    // <patch>
    internal static async Task PatchAsync(HttpClient client)
    {
        using StringContent jsonContent = new(
            JsonSerializer.Serialize(new
            {
                completed = true
            }),
            Encoding.UTF8,
            "application/json");

        using HttpResponseMessage response = await client.PatchAsync(
            "todos/1",
            jsonContent);

        response.EnsureSuccessStatusCode();
        response.WriteToConsole();
        
        var jsonResponse = await response.Content.ReadAsStringAsync();        
        Console.WriteLine($"🏁 {jsonResponse}\n");
    }
    // </patch>
}
