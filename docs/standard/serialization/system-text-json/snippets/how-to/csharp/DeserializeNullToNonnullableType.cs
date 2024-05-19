using System.Text.Json;

namespace SystemTextJsonSamples
{
    public class DeserializeNullToNonnullableType
    {
        public static void Run()
        {
            string jsonString;
            var wf = WeatherForecastFactories.CreateWeatherForecast();

            var options = new JsonSerializerOptions
            {
                WriteIndented = true,
                Converters =
                {
                    new DateTimeOffsetNullHandlingConverter()
                }
            };
            jsonString = JsonSerializer.Serialize(wf, options);
            Console.WriteLine($"JSON with valid Date:\n{jsonString}\n");

            wf = JsonSerializer.Deserialize<WeatherForecast>(jsonString, options)!;
            wf.DisplayPropertyValues();

            jsonString = @"{""Date"": null,""TemperatureCelsius"": 25,""Summary"":""Hot""}";
            Console.WriteLine($"JSON with null Date:\n{jsonString}\n");

            // The null-date JSON deserializes with error if the converter isn't used.
            try
            {
                wf = JsonSerializer.Deserialize<WeatherForecast>(jsonString);
            }
            catch (JsonException ex)
            {
                Console.WriteLine($"Exception thrown: {ex.Message}\n");
            }

            Console.WriteLine("Deserialize with converter");
            wf = JsonSerializer.Deserialize<WeatherForecast>(jsonString, options)!;
            wf.DisplayPropertyValues();
        }
    }
}
