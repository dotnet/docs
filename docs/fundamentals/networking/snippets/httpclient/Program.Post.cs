internal static partial class Program
{
    // <post>
    internal static async Task PostAsync(HttpClient client)
    {
        using StringContent jsonContent = new(
            JsonSerializer.Serialize(new
            {
                userId = 77,
                id = 1,
                title = "write code sample",
                completed = false
            }),
            Encoding.UTF8,
            "application/json");

        using HttpResponseMessage response = await client.PostAsync(
            "todos",
            jsonContent);

        response.EnsureSuccessStatusCode();
        response.WriteToConsole();
        
        var jsonResponse = await response.Content.ReadAsStringAsync();
        Console.WriteLine($"🏁 {jsonResponse}\n");
    }
    // </post>
}
