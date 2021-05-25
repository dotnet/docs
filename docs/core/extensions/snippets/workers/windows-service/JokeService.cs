using System;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;

namespace App.WindowsService
{
    public class JokeService
    {
        private readonly JsonSerializerOptions _options = new()
        {
            PropertyNameCaseInsensitive = true
        };

        private readonly HttpClient _httpClient;

        public JokeService(HttpClient httpClient) => _httpClient = httpClient;

        public async Task<string> GetJokeAsync()
        {
            try
            {
                // The API returns an array with a single entry.
                Joke[]? jokes = await _httpClient.GetFromJsonAsync<Joke[]>(
                        "https://official-joke-api.appspot.com/jokes/programming/random", _options);

                Joke? joke = jokes?.FirstOrDefault();

                return joke is not null
                    ? $"{joke.Setup}{Environment.NewLine}{joke.Punchline}"
                    : "That's not funny!";
            }
            catch (Exception ex)
            {
                return $"That's not funny! {ex}";
            }
        }
    }

    public record Joke(int Id, string Setup, string Punchline);
}
