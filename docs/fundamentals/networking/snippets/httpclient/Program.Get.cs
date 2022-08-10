static partial class Program
{
    // <get>
    static async Task GetAsync(HttpClient client)
    {
        using HttpResponseMessage response = await client.GetAsync("todos/3");
        
        response.EnsureSuccessStatusCode()
            .WriteRequestToConsole();
        
        var jsonResponse = await response.Content.ReadAsStringAsync();
        WriteLine($"{jsonResponse}\n");

        // Expected output:
        //   https://jsonplaceholder.typicode.com/todos/3
        //   GET HTTP/ 1.1
        //   {
        //     "userId": 1,
        //     "id": 3,
        //     "title": "fugiat veniam minus",
        //     "completed": false
        //   }
    }
    // </get>
}
