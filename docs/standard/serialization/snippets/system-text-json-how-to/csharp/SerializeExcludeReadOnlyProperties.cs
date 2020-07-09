using System;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;

namespace SystemTextJsonSamples
{
    public class SerializeExcludeReadOnlyProperties
    {
        public static void Run()
        {
            string jsonString;
            WeatherForecastWithROProperty weatherForecast = WeatherForecastFactories.CreateWeatherForecastWithROProperty();
            weatherForecast.DisplayPropertyValues();

            // <SnippetSerialize>
            var options = new JsonSerializerOptions
            {
                IgnoreReadOnlyProperties = true,
                WriteIndented = true
            };
            jsonString = JsonSerializer.Serialize(weatherForecast, options);
            // </SnippetSerialize>
            Console.WriteLine(jsonString);
            Console.WriteLine();
        }
    }
}
