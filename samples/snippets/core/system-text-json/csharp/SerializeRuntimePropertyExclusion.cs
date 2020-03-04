using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace SystemTextJsonSamples
{
    public class SerializeRuntimePropertyExclusion
    {
        public static void Run()
        {
            string jsonString;
            var wf = WeatherForecastFactories.CreateWeatherForecast();
            wf.DisplayPropertyValues();

            var serializeOptions = new JsonSerializerOptions();
            serializeOptions.Converters.Add(new WeatherForecastRuntimeIgnoreConverter());
            serializeOptions.WriteIndented = true;
            jsonString = JsonSerializer.Serialize(wf, serializeOptions);
            Console.WriteLine($"JSON output:\n{jsonString}\n");

            wf.Summary = "N/A";
            wf.DisplayPropertyValues();
            serializeOptions = new JsonSerializerOptions();
            serializeOptions.Converters.Add(new WeatherForecastRuntimeIgnoreConverter());
            serializeOptions.WriteIndented = true;
            jsonString = JsonSerializer.Serialize(wf, serializeOptions);
            Console.WriteLine($"JSON output:\n{jsonString}\n");

            var deserializeOptions = new JsonSerializerOptions();
            deserializeOptions.Converters.Add(new WeatherForecastRuntimeIgnoreConverter());
            wf = JsonSerializer.Deserialize<WeatherForecast>(jsonString, deserializeOptions);
            wf.DisplayPropertyValues();
        }
    }
}
