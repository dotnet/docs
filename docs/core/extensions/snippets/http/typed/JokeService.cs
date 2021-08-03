using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Shared;

namespace TypedHttp.Example
{
    public sealed class JokeService : IDisposable
    {
        private readonly HttpClient _httpClient = null!;
        private readonly ILogger<JokeService> _logger = null!;

        public JokeService(
            HttpClient httpClient,
            ILogger<JokeService> logger) =>
            (_httpClient, _logger) = (httpClient, logger);

        public async Task<string> GetRandomJokeAsync()
        {
            try
            {
                // Make HTTP GET request
                // Parse JSON response deserialize into ChuckNorrisJoke type
                ChuckNorrisJoke? result = await _httpClient.GetFromJsonAsync<ChuckNorrisJoke>(
                    "https://api.icndb.com/jokes/random?limitTo=[nerdy]",
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

        void IDisposable.Dispose() => _httpClient?.Dispose();
    }
}
