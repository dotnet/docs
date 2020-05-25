using System;
using System.Collections.Generic;
using System.Text.Json;

namespace SystemTextJsonSamples
{
    public class SerializeCamelCaseDictionaryKeys
    {
        public static void Run()
        {
            string jsonString;
            WeatherForecastWithDictionary weatherForecast = WeatherForecastFactories.CreateWeatherForecastWithDictionary();
            weatherForecast.DisplayPropertyValues();

            // <SnippetSerialize>
            var options = new JsonSerializerOptions
            {
                DictionaryKeyPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true
            };
            jsonString = JsonSerializer.Serialize(weatherForecast, options);
            // </SnippetSerialize>
            Console.WriteLine($"JSON output:\n{jsonString}\n");

            // <SnippetDeserialize>
            weatherForecast = JsonSerializer.Deserialize<WeatherForecastWithDictionary>(jsonString);
            // </SnippetDeserialize>
            weatherForecast.DisplayPropertyValues();
        }
    }
}
