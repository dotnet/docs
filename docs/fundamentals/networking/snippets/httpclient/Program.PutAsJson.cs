static partial class Program
{
    // <putasjson>
    static async Task PutAsJsonAsync(HttpClient httpClient)
    {
        using HttpResponseMessage response = await httpClient.PutAsJsonAsync(
            "todos/5",
            new Todo(Title: "partially update todo", Completed: true));

        response.EnsureSuccessStatusCode()
            .WriteRequestToConsole();

        var todo = await response.Content.ReadFromJsonAsync<Todo>();
        Console.WriteLine($"{todo}\n");

        // Expected output:
        //   PUT https://jsonplaceholder.typicode.com/todos/5 HTTP/1.1
        //   Todo { UserId = , Id = 5, Title = partially update todo, Completed = True }
    }
    // </putasjson>
}
