static partial class Program
{
    // <delete>
    static async Task DeleteAsync(HttpClient client)
    {
        using HttpResponseMessage response =
            await client.DeleteAsync("todos/1");
        
        response.EnsureSuccessStatusCode();
        response.WriteToConsole();

        var jsonResponse = await response.Content.ReadAsStringAsync();
        WriteLine($"{jsonResponse}\n");

        // Expected output
        //   DELETE https://jsonplaceholder.typicode.com/todos/1 HTTP/1.1
        //   {}
    }
    // </delete>
}
