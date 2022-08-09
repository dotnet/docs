internal static partial class Program
{
    // <put>
    internal static async Task PutAsJsonAsync(HttpClient client)
    {
        using HttpResponseMessage response = await client.PutAsJsonAsync(
            "todos/5",
            new Todo(Title: "partially update todo", Completed: true));

        response.EnsureSuccessStatusCode();
        response.WriteToConsole();

        var todo = await response.Content.ReadFromJsonAsync<Todo>();
        Console.WriteLine($"🏁 {todo}\n");
    }
    // </put>
}
