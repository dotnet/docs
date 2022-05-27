using System.Net.Http.Json;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Shared;

namespace NamedHttp.Example;

public class JokeService
{
    private readonly IHttpClientFactory _httpClientFactory = null!;
    private readonly IConfiguration _configuration = null!;
    private readonly ILogger<JokeService> _logger = null!;

    public JokeService(
        IHttpClientFactory httpClientFactory,
        IConfiguration configuration,
        ILogger<JokeService> logger) =>
        (_httpClientFactory, _configuration, _logger) =
            (httpClientFactory, configuration, logger);

    public async Task<string> GetRandomJokeAsync()
    {
        // Create the client
        string httpClientName = _configuration["JokeHttpClientName"];
        HttpClient client = _httpClientFactory.CreateClient(httpClientName);

        try
        {
            // Make HTTP GET request
            // Parse JSON response deserialize into ChuckNorrisJoke type
            ChuckNorrisJoke? result = await client.GetFromJsonAsync<ChuckNorrisJoke>(
                "jokes/random?limitTo=[nerdy]",
                DefaultJsonSerialization.Options);

            if (result?.Value?.Joke is not null)
            {
                return result.Value.Joke;
            }
        }
        catch (Exception ex)
        {
            _logger.LogError("Error getting something fun to say: {Error}", ex);
        }

        return "Oops, something has gone wrong - that's not funny at all!";
    }
}
