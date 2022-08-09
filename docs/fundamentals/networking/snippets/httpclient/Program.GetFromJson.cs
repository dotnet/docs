static partial class Program
{
    // <getfromjson>
    static async Task GetFromJsonAsync(HttpClient client)
    {
        var todos = await client.GetFromJsonAsync<List<Todo>>(
            "todos?userId=1&completed=false");

        todos?.ForEach(WriteLine);
        WriteLine();
    }
    // </getfromjson>
}
