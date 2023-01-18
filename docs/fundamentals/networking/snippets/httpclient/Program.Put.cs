static partial class Program
{
    // <put>
    static async Task PutAsync(HttpClient httpClient)
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

        using HttpResponseMessage response = await httpClient.PutAsync(
            "todos/1",
            jsonContent);

        response.EnsureSuccessStatusCode()
            .WriteRequestToConsole();
        
        var jsonResponse = await response.Content.ReadAsStringAsync();
        WriteLine($"{jsonResponse}\n");

        // Expected output:
        //   PUT https://jsonplaceholder.typicode.com/todos/1 HTTP/1.1
        //   {
        //     "userId": 1,
        //     "id": 1,
        //     "title": "foo bar",
        //     "completed": false
        //   }
    }
    // </put>
}
