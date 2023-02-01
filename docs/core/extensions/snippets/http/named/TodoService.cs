using System.Net.Http.Json;
using System.Text.Json;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Shared;

namespace NamedHttp.Example;

public sealed class TodoService
{
    private readonly IHttpClientFactory _httpClientFactory = null!;
    private readonly IConfiguration _configuration = null!;
    private readonly ILogger<TodoService> _logger = null!;

    public TodoService(
        IHttpClientFactory httpClientFactory,
        IConfiguration configuration,
        ILogger<TodoService> logger) =>
        (_httpClientFactory, _configuration, _logger) =
            (httpClientFactory, configuration, logger);

    public async Task<Todo[]> GetUserTodosAsync(int userId)
    {
        // Create the client
        string? httpClientName = _configuration["TodoHttpClientName"];
        using HttpClient client = _httpClientFactory.CreateClient(httpClientName ?? "");

        try
        {
            // Make HTTP GET request
            // Parse JSON response deserialize into Todo type
            Todo[]? todos = await client.GetFromJsonAsync<Todo[]>(
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
}
