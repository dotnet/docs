﻿using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;

namespace App.WindowsService
{
    public class JokeService
    {
        private readonly HttpClient _httpClient;
        private readonly JsonSerializerOptions _options = new()
        {
            PropertyNameCaseInsensitive = true
        };

        private const string JokeApiUrl =
            "https://official-joke-api.appspot.com/jokes/programming/random";

        public JokeService(HttpClient httpClient) => _httpClient = httpClient;

        public async Task<string> GetJokeAsync()
        {
            try
            {
                // The API returns an array with a single entry.
                Joke[]? jokes = await _httpClient.GetFromJsonAsync<Joke[]>(
                    JokeApiUrl, _options);

                Joke? joke = jokes?[0];

                return joke is not null
                    ? $"{joke.Setup}{Environment.NewLine}{joke.Punchline}"
                    : "No joke here...";
            }
            catch (Exception ex)
            {
                return $"That's not funny! {ex}";
            }
        }
    }

    public record Joke(int Id, string Type, string Setup, string Punchline);
}
