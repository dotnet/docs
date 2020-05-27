using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace SystemTextJsonSamples
{
    public class RoundtripPropertyNamingPolicy
    {
        public static void Run()
        {
            string jsonString;
            WeatherForecast weatherForecast = WeatherForecastFactories.CreateWeatherForecast();
            weatherForecast.DisplayPropertyValues();

            // <SnippetSerialize>
            var options = new JsonSerializerOptions
            {
                PropertyNamingPolicy = new UpperCaseNamingPolicy(),
                WriteIndented = true
            };
            jsonString = JsonSerializer.Serialize(weatherForecast, options);
            // </SnippetSerialize>
            Console.WriteLine($"JSON output:\n{jsonString}\n");

            // <SnippetDeserialize>
            options = new JsonSerializerOptions
            {
                PropertyNamingPolicy = new UpperCaseNamingPolicy()
            };
            weatherForecast = JsonSerializer.Deserialize<WeatherForecast>(jsonString, options);
            // </SnippetDeserialize>
            weatherForecast.DisplayPropertyValues();
        }
    }
}
