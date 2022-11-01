static partial class Program
{
    // <get>
    static async Task GetAsync(HttpClient httpClient)
    {
        using HttpResponseMessage response = await httpClient.GetAsync("todos/3");
        
        response.EnsureSuccessStatusCode()
            .WriteRequestToConsole();
        
        var jsonResponse = await response.Content.ReadAsStringAsync();
        WriteLine($"{jsonResponse}\n");

        // Expected output:
        //   GET https://jsonplaceholder.typicode.com/todos/3 HTTP/ 1.1
        //   {
        //     "userId": 1,
        //     "id": 3,
        //     "title": "fugiat veniam minus",
        //     "completed": false
        //   }
    }
    // </get>
}
