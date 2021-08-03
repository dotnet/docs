using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Shared;

namespace NamedHttp.Example
{
    public class JokeService
    {
        private readonly IHttpClientFactory _httpClientFactory = null!;
        private readonly ILogger<JokeService> _logger = null!;

        public JokeService(
            IHttpClientFactory httpClientFactory,
            ILogger<JokeService> logger) =>
            (_httpClientFactory, _logger) = (httpClientFactory, logger);

        public async Task<string> GetRandomJokeAsync()
        {
            // Create the client
            HttpClient client = _httpClientFactory.CreateClient(nameof(JokeService));

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

            return "Oops, something has gone wrong - that's funny at all!";
        }
    }
}
