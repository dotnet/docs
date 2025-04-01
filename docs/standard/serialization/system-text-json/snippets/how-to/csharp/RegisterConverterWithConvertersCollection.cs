using System.Text.Json;

namespace SystemTextJsonSamples
{
    public class RegisterConverterWithConverterscollection
    {
        public static void Run()
        {
            string jsonString;
            WeatherForecast weatherForecast = WeatherForecastFactories.CreateWeatherForecast();
            weatherForecast.DisplayPropertyValues();

            // <Serialize>
            var serializeOptions = new JsonSerializerOptions
            {
                WriteIndented = true
            };
			serializeOptions.Converters.Add(new DateTimeOffsetJsonConverter());
            
            jsonString = JsonSerializer.Serialize(weatherForecast, serializeOptions);
            // </Serialize>
            Console.WriteLine($"JSON output:\n{jsonString}\n");

            // <Deserialize>
            var deserializeOptions = new JsonSerializerOptions();
            deserializeOptions.Converters.Add(new DateTimeOffsetJsonConverter());
            weatherForecast = JsonSerializer.Deserialize<WeatherForecast>(jsonString, deserializeOptions)!;
            // </Deserialize>
            weatherForecast.DisplayPropertyValues();
        }
    }
}
