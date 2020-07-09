using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace SystemTextJsonSamples
{
    public class RegisterConverterWithAttributeOnProperty

    {
        public static void Run()
        {
            string jsonString;
            WeatherForecastWithConverterAttribute weatherForecast = WeatherForecastFactories.CreateWeatherForecastWithConverterAttribute();
            weatherForecast.DisplayPropertyValues();

            // <SnippetSerialize>
            var serializeOptions = new JsonSerializerOptions();
            serializeOptions.WriteIndented = true;
            jsonString = JsonSerializer.Serialize(weatherForecast, serializeOptions);
            // </SnippetSerialize>
            Console.WriteLine($"JSON output:\n{jsonString}\n");

            // <SnippetDeserialize>
            weatherForecast = JsonSerializer.Deserialize<WeatherForecastWithConverterAttribute>(jsonString);
            // </SnippetDeserialize>
            weatherForecast.DisplayPropertyValues();
        }
    }
}
