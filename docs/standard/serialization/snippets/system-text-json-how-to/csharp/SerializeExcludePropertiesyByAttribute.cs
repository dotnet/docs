using System;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;

namespace SystemTextJsonSamples
{
    public class SerializeExcludePropertiesByAttribute
    {
        public static void Run()
        {
            string jsonString;
            WeatherForecastWithIgnoreAttribute weatherForecast = WeatherForecastFactories.CreateWeatherForecastWithIgnoreAttribute();
            weatherForecast.DisplayPropertyValues();

            // <SnippetSerialize>
            var options = new JsonSerializerOptions
            {
                WriteIndented = true
            };
            jsonString = JsonSerializer.Serialize(weatherForecast, options);
            // </SnippetSerialize>
            Console.WriteLine(jsonString);
            Console.WriteLine();
        }
    }
}
