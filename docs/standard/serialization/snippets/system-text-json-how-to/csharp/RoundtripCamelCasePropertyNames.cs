using System;
using System.Text.Json;

namespace SystemTextJsonSamples
{
    public class RoundtripCamelCasePropertyNames
    {
        public static void Run()
        {
            string jsonString;
            WeatherForecastWithPropertyNameAttribute weatherForecast = WeatherForecastFactories.CreateWeatherForecastWithPropertyNameAttribute();
            weatherForecast.DisplayPropertyValues();

            // <SnippetSerialize>
            var serializeOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true
            };
            jsonString = JsonSerializer.Serialize(weatherForecast, serializeOptions);
            // </SnippetSerialize>
            Console.WriteLine($"JSON output:\n{jsonString}\n");

            // <SnippetDeserialize>
            var deserializeOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };
            weatherForecast = JsonSerializer.Deserialize<WeatherForecastWithPropertyNameAttribute>(jsonString, deserializeOptions);
            // </SnippetDeserialize>
            weatherForecast.DisplayPropertyValues();
        }
    }
}
