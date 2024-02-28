using System.Net.Http.Json;
using System.Text.Json;
using Microsoft.Extensions.Logging;
using Shared;

namespace BasicHttp.Example;

public sealed class TodoService(
    IHttpClientFactory httpClientFactory,
    ILogger<TodoService> logger)
{
    public async Task<Todo[]> GetUserTodosAsync(int userId)
    {
        // Create the client
        HttpClient client = httpClientFactory.CreateClient();
        
        try
        {
            // Make HTTP GET request
            // Parse JSON response deserialize into Todo types
            Todo[]? todos = await client.GetFromJsonAsync<Todo[]>(
                $"https://jsonplaceholder.typicode.com/todos?userId={userId}",
                new JsonSerializerOptions(JsonSerializerDefaults.Web));

            return todos ?? [];
        }
        catch (Exception ex)
        {
            logger.LogError("Error getting something fun to say: {Error}", ex);
        }

        return [];
    }
}
