static partial class Program
{
    // <delete>
    static async Task DeleteAsync(HttpClient httpClient)
    {
        using HttpResponseMessage response = await httpClient.DeleteAsync("todos/1");
        
        response.EnsureSuccessStatusCode()
            .WriteRequestToConsole();

        var jsonResponse = await response.Content.ReadAsStringAsync();
        Console.WriteLine($"{jsonResponse}\n");

        // Expected output
        //   DELETE https://jsonplaceholder.typicode.com/todos/1 HTTP/1.1
        //   {}
    }
    // </delete>
}
