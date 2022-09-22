using System.Text.Json;

namespace SystemTextJsonSamples
{
    public class DeserializeRequiredProperty
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
                    new WeatherForecastRequiredPropertyConverter()
                }
            };
            jsonString = JsonSerializer.Serialize(wf, options);
            Console.WriteLine($"JSON with Date:\n{jsonString}\n");

            wf = JsonSerializer.Deserialize<WeatherForecast>(jsonString, options)!;
            wf.DisplayPropertyValues();

            jsonString = @"{""TemperatureCelsius"": 25,""Summary"":""Hot""}";
            Console.WriteLine($"JSON without Date:\n{jsonString}\n");

            // The missing-date JSON deserializes without error if the converter isn't used.
            Console.WriteLine("Deserialize without converter");
            wf = JsonSerializer.Deserialize<WeatherForecast>(jsonString)!;
            wf.DisplayPropertyValues();

            Console.WriteLine("Deserialize with converter");
            try
            {
                wf = JsonSerializer.Deserialize<WeatherForecast>(jsonString, options)!;
            }
            catch (JsonException ex)
            {
                Console.WriteLine($"Exception thrown: {ex.Message}\n");
            }
            // wf object is unchanged if exception is thrown.
            wf.DisplayPropertyValues();
        }
    }
}
