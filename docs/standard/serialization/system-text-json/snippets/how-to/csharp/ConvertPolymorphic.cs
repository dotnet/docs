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
            // <SerializeDefault>
            var serializeOptions = new JsonSerializerOptions
            {
                WriteIndented = true
            };
            jsonString = JsonSerializer.Serialize<WeatherForecast>(weatherForecast, serializeOptions);
            // </SerializeDefault>

            Console.WriteLine($"JSON output:\n{jsonString}\n");

            Console.WriteLine("Object generic type parameter - derived class properties included");
            // <SerializeObject>
            serializeOptions = new JsonSerializerOptions
            {
                WriteIndented = true
            };
            jsonString = JsonSerializer.Serialize<object>(weatherForecast, serializeOptions);
            // </SerializeObject>
            Console.WriteLine($"JSON output:\n{jsonString}\n");

            Console.WriteLine("GetType() type parameter - derived class properties included");
            // <SerializeGetType>
            serializeOptions = new JsonSerializerOptions
            {
                WriteIndented = true
            };
            jsonString = JsonSerializer.Serialize(weatherForecast, weatherForecast.GetType(), serializeOptions);
            // </SerializeGetType>
            Console.WriteLine($"JSON output:\n{jsonString}\n");
        }
    }
}
