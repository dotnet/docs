using System;
using System.Text.Json;

namespace SystemTextJsonSamples
{
    class RegisterConverterWithAttributeOnType
    {
        public static void Run()
        {
            string jsonString;
            WeatherForecastWithTemperatureStruct weatherForecast = WeatherForecastFactories.CreateWeatherForecastWithTemperatureStruct();
            weatherForecast.DisplayPropertyValues();

            // <SnippetSerialize>
            var serializeOptions = new JsonSerializerOptions
            {
                WriteIndented = true
            };
            jsonString = JsonSerializer.Serialize(weatherForecast, serializeOptions);
            // </SnippetSerialize>
            Console.WriteLine($"JSON output:\n{jsonString}\n");

            // <SnippetDeserialize>
            weatherForecast = JsonSerializer.Deserialize<WeatherForecastWithTemperatureStruct>(jsonString);
            weatherForecast.DisplayPropertyValues();
            // </SnippetDeserialize>
        }
    }
}
