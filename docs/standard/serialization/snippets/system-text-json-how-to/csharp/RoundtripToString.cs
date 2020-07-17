using System;
using System.Text.Json;

namespace SystemTextJsonSamples
{
    public class RoundtripToString
    {
        public static void Run()
        {
            WeatherForecastWithPOCOs weatherForecast = WeatherForecastFactories.CreateWeatherForecastWithPOCOs();
            weatherForecast.DisplayPropertyValues();

            // <SnippetSerialize>
            string jsonString;
            jsonString = JsonSerializer.Serialize(weatherForecast);
            // </SnippetSerialize>

            // <SnippetSerializeWithGenericParameter>
            jsonString = JsonSerializer.Serialize<WeatherForecastWithPOCOs>(weatherForecast);
            // </SnippetSerializeWithGenericParameter>

            Console.WriteLine($"JSON output:\n{jsonString}\n");

            // <SnippetSerializePrettyPrint>
            var options = new JsonSerializerOptions
            {
                WriteIndented = true,
            };
            jsonString = JsonSerializer.Serialize(weatherForecast, options);
            // </SnippetSerializePrettyPrint>
            Console.WriteLine($"Pretty-printed JSON output:\n{jsonString}\n");

            // <SnippetDeserialize>
            weatherForecast = JsonSerializer.Deserialize<WeatherForecastWithPOCOs>(jsonString);
            // </SnippetDeserialize>
            weatherForecast.DisplayPropertyValues();
        }
    }
}
