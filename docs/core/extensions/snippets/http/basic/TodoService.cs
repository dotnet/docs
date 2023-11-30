using System.Net.Http.Json;
using System.Text.Json;
using Microsoft.Extensions.Logging;
using Shared;

namespace BasicHttp.Example;

public sealed class TodoService
{
    private readonly IHttpClientFactory _httpClientFactory = null!;
    private readonly ILogger<TodoService> _logger = null!;

    public TodoService(
        IHttpClientFactory httpClientFactory,
        ILogger<TodoService> logger) =>
        (_httpClientFactory, _logger) = (httpClientFactory, logger);

    public async Task<Todo[]> GetUserTodosAsync(int userId)
    {
        // Create the client
        using HttpClient client = _httpClientFactory.CreateClient();
        
        try
        {
            // Make HTTP GET request
            // Parse JSON response deserialize into Todo types
            Todo[]? todos = await client.GetFromJsonAsync<Todo[]>(
                $"https://jsonplaceholder.typicode.com/todos?userId={userId}",
                new JsonSerializerOptions(JsonSerializerDefaults.Web));

            return todos ?? Array.Empty<Todo>();
        }
        catch (Exception ex)
        {
            _logger.LogError("Error getting something fun to say: {Error}", ex);
        }

        return Array.Empty<Todo>();
    }
}
