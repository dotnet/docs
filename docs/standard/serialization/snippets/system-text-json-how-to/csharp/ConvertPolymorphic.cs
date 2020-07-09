using System;
using System.Text.Json;

namespace SystemTextJsonSamples
{
    public class ConvertPolymorphic
    {
        public static void Run()
        {
            string jsonString;
            var weatherForecastDerived = WeatherForecastFactories.CreateWeatherForecastDerived();
            WeatherForecast weatherForecast = weatherForecastDerived;
            weatherForecast.DisplayPropertyValues();

            Console.WriteLine("Base class generic type - derived class properties omitted");
            // <SnippetSerializeDefault>
            var serializeOptions = new JsonSerializerOptions
            {
                WriteIndented = true
            };
            jsonString = JsonSerializer.Serialize<WeatherForecast>(weatherForecast, serializeOptions);
            // </SnippetSerializeDefault>

            Console.WriteLine($"JSON output:\n{jsonString}\n");

            Console.WriteLine("Object generic type parameter - derived class properties included");
            // <SnippetSerializeObject>
            serializeOptions = new JsonSerializerOptions
            {
                WriteIndented = true
            };
            jsonString = JsonSerializer.Serialize<object>(weatherForecast, serializeOptions);
            // </SnippetSerializeObject>
            Console.WriteLine($"JSON output:\n{jsonString}\n");

            Console.WriteLine("GetType() type parameter - derived class properties included");
            // <SnippetSerializeGetType>
            serializeOptions = new JsonSerializerOptions
            {
                WriteIndented = true
            };
            jsonString = JsonSerializer.Serialize(weatherForecast, weatherForecast.GetType(), serializeOptions);
            // </SnippetSerializeGetType>
            Console.WriteLine($"JSON output:\n{jsonString}\n");
        }
    }
}
