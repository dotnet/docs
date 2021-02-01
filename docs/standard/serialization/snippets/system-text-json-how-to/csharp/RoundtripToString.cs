using System;
using System.Text.Json;

namespace SystemTextJsonSamples
{
    public class RoundtripToString
    {
        public static void Run()
        {
            WeatherForecastWithPOCOs weatherForecast =
                WeatherForecastFactories.CreateWeatherForecastWithPOCOs();
            weatherForecast.DisplayPropertyValues();

            // <Serialize>
            string jsonString = JsonSerializer.Serialize(weatherForecast);
            // </Serialize>

            // <SerializeWithGenericParameter>
            jsonString = JsonSerializer.Serialize<WeatherForecastWithPOCOs>(weatherForecast);
            // </SerializeWithGenericParameter>

            Console.WriteLine($"JSON output:\n{jsonString}\n");

            // <SerializePrettyPrint>
            var options = new JsonSerializerOptions
            {
                WriteIndented = true,
            };
            jsonString = JsonSerializer.Serialize(weatherForecast, options);
            // </SerializePrettyPrint>
            Console.WriteLine($"Pretty-printed JSON output:\n{jsonString}\n");

            // <Deserialize>
            weatherForecast = JsonSerializer.Deserialize<WeatherForecastWithPOCOs>(jsonString);
            // </Deserialize>
            weatherForecast.DisplayPropertyValues();
        }
    }
}
