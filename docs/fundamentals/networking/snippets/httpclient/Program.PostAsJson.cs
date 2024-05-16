static partial class Program
{
    // <postasjson>
    static async Task PostAsJsonAsync(HttpClient httpClient)
    {
        using HttpResponseMessage response = await httpClient.PostAsJsonAsync(
            "todos", 
            new Todo(UserId: 9, Id: 99, Title: "Show extensions", Completed: false));

        response.EnsureSuccessStatusCode()
            .WriteRequestToConsole();

        var todo = await response.Content.ReadFromJsonAsync<Todo>();
        Console.WriteLine($"{todo}\n");

        // Expected output:
        //   POST https://jsonplaceholder.typicode.com/todos HTTP/1.1
        //   Todo { UserId = 9, Id = 201, Title = Show extensions, Completed = False }
    }
    // </postasjson>
}
