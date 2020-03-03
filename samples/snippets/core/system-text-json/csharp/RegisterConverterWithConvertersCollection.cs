using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace SystemTextJsonSamples
{
    public class RegisterConverterWithConverterscollection
    {
        public static void Run()
        {
            string jsonString;
            WeatherForecast weatherForecast = WeatherForecastFactories.CreateWeatherForecast();
            weatherForecast.DisplayPropertyValues();

            // <SnippetSerialize>
            var serializeOptions = new JsonSerializerOptions();
            serializeOptions.Converters.Add(new DateTimeOffsetConverter());
            serializeOptions.WriteIndented = true;
            jsonString = JsonSerializer.Serialize(weatherForecast, serializeOptions);
            // </SnippetSerialize>
            Console.WriteLine($"JSON output:\n{jsonString}\n");

            // <SnippetDeserialize>
            var deserializeOptions = new JsonSerializerOptions();
            deserializeOptions.Converters.Add(new DateTimeOffsetConverter());
            weatherForecast = JsonSerializer.Deserialize<WeatherForecast>(jsonString, deserializeOptions);
            // </SnippetDeserialize>
            weatherForecast.DisplayPropertyValues();
        }
    }
}
