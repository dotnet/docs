static partial class Program
{
    // <put>
    static async Task PutAsync(HttpClient client)
    {
        using StringContent jsonContent = new(
            JsonSerializer.Serialize(new 
            {
                userId = 1,
                id = 1,
                title = "foo bar",
                completed = false
            }),
            Encoding.UTF8,
            "application/json");

        using HttpResponseMessage response = await client.PutAsync(
            "todos/1",
            jsonContent);

        response.EnsureSuccessStatusCode();
        response.WriteToConsole();
        
        var jsonResponse = await response.Content.ReadAsStringAsync();
        WriteLine($"{jsonResponse}\n");
    }
    // </put>
}
