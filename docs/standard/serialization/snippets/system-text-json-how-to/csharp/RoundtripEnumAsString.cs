using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace SystemTextJsonSamples
{
    public class RoundtripEnumAsString
    {
        public static void Run()
        {
            string jsonString;
            WeatherForecastWithEnum weatherForecast = WeatherForecastFactories.CreateWeatherForecastWithEnum();
            weatherForecast.DisplayPropertyValues();

            var options = new JsonSerializerOptions
            {
                WriteIndented = true,
            };
            jsonString = JsonSerializer.Serialize(weatherForecast, options);
            Console.WriteLine($"JSON with enum as number:\n{jsonString}\n");

            // <SnippetSerialize>
            options = new JsonSerializerOptions();
            options.Converters.Add(new JsonStringEnumConverter(JsonNamingPolicy.CamelCase));
            options.WriteIndented = true;
            jsonString = JsonSerializer.Serialize(weatherForecast, options);
            // </SnippetSerialize>
            Console.WriteLine($"JSON with enum as string:\n{jsonString}\n");

            // <SnippetDeserialize>
            options = new JsonSerializerOptions();
            options.Converters.Add(new JsonStringEnumConverter(JsonNamingPolicy.CamelCase));
            weatherForecast = JsonSerializer.Deserialize<WeatherForecastWithEnum>(jsonString, options);
            // </SnippetDeserialize>
            weatherForecast.DisplayPropertyValues();
        }
    }
}
