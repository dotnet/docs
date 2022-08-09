internal static partial class Program
{
    // <postasjson>
    internal static async Task PostAsJsonAsync(HttpClient client)
    {
        using HttpResponseMessage response = await client.PostAsJsonAsync(
            "todos", 
            new Todo(UserId: 9, Id: 99, Title: "Show extensions", Completed: false));

        response.EnsureSuccessStatusCode();
        response.WriteToConsole();

        var todo = await response.Content.ReadFromJsonAsync<Todo>();
        Console.WriteLine($"🏁 {todo}\n");
    }
    // </postasjson>
}
