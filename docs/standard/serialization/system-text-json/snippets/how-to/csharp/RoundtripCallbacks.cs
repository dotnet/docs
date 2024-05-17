using System.Text.Json;

namespace SystemTextJsonSamples
{
    public class RoundtripCallbacks
    {
        public static void Run()
        {
            string jsonString;
            var wf = WeatherForecastFactories.CreateWeatherForecast();
            wf.DisplayPropertyValues();

            // <Serialize>
            var serializeOptions = new JsonSerializerOptions
            {
                WriteIndented = true,
                Converters =
                {
                    new WeatherForecastCallbacksConverter()
                }
            };
            
            jsonString = JsonSerializer.Serialize(wf, serializeOptions);
            // </Serialize>

            Console.WriteLine($"JSON output:\n{jsonString}\n");

            // <Deserialize>
            var deserializeOptions = new JsonSerializerOptions
            {
                Converters =
                {
                    new WeatherForecastCallbacksConverter()
                }
            };
            wf = JsonSerializer.Deserialize<WeatherForecast>(jsonString, deserializeOptions)!;
            // <Deserialize>

            wf.DisplayPropertyValues();
        }
    }
}
