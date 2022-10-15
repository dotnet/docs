static partial class Program
{
    // <patch>
    static async Task PatchAsync(HttpClient httpClient)
    {
        using StringContent jsonContent = new(
            JsonSerializer.Serialize(new
            {
                completed = true
            }),
            Encoding.UTF8,
            "application/json");

        using HttpResponseMessage response = await httpClient.PatchAsync(
            "todos/1",
            jsonContent);

        response.EnsureSuccessStatusCode()
            .WriteRequestToConsole();

        var jsonResponse = await response.Content.ReadAsStringAsync();
        WriteLine($"{jsonResponse}\n");

        // Expected output
        //   PATCH https://jsonplaceholder.typicode.com/todos/1 HTTP/1.1
        //   {
        //     "userId": 1,
        //     "id": 1,
        //     "title": "delectus aut autem",
        //     "completed": true
        //   }
    }
    // </patch>
}
