using System.Net.Http.Json;
using System.Text.Json;
using Microsoft.Extensions.Logging;
using Shared;

namespace TypedHttp.Example;

public sealed class TodoService : IDisposable
{
    private readonly HttpClient _httpClient = null!;
    private readonly ILogger<TodoService> _logger = null!;

    public TodoService(
        HttpClient httpClient,
        ILogger<TodoService> logger) =>
        (_httpClient, _logger) = (httpClient, logger);

    public async Task<Todo[]> GetUserTodosAsync(int userId)
    {
        try
        {
            // Make HTTP GET request
            // Parse JSON response deserialize into Todo type
            Todo[]? todos = await _httpClient.GetFromJsonAsync<Todo[]>(
                $"todos?userId={userId}",
                new JsonSerializerOptions(JsonSerializerDefaults.Web));

            return todos ?? Array.Empty<Todo>();
        }
        catch (Exception ex)
        {
            _logger.LogError("Error getting something fun to say: {Error}", ex);
        }

        return Array.Empty<Todo>();
    }

    public void Dispose() => _httpClient?.Dispose();
}
