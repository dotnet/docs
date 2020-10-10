using System;
using System.Text.Json;

namespace SystemTextJsonSamples
{
    public class RoundtripToString
    {
        public static void Run()
        {
            SystemTextJsonSamples_2.WeatherForecast weatherForecast = WeatherForecastFactories.CreateWeatherForecastWithPOCOs();
            weatherForecast.DisplayPropertyValues();

            // <SnippetSerialize>
            string jsonString;
            jsonString = JsonSerializer.Serialize(weatherForecast);
            // </SnippetSerialize>

            // <SnippetSerializeWithGenericParameter>
            jsonString = JsonSerializer.Serialize<WeatherForecast>(weatherForecast);
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
            weatherForecast = JsonSerializer.Deserialize<WeatherForecast>(jsonString);
            // </SnippetDeserialize>
            weatherForecast.DisplayPropertyValues();
        }
    }
}
