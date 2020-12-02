using System;
using System.Text;
using System.Text.Json;

namespace SystemTextJsonSamples
{
    public class RoundtripToUtf8
    {
        public static void Run()
        {
            WeatherForecast weatherForecast = WeatherForecastFactories.CreateWeatherForecast();
            weatherForecast.DisplayPropertyValues();

            // <Serialize>
            byte[] jsonUtf8Bytes;
            var options = new JsonSerializerOptions
            {
                WriteIndented = true
            };
            jsonUtf8Bytes = JsonSerializer.SerializeToUtf8Bytes(weatherForecast, options);
            // </Serialize>
            Console.WriteLine($"JSON output:\n{Encoding.UTF8.GetString(jsonUtf8Bytes)}\n");

            // <Deserialize1>
            var readOnlySpan = new ReadOnlySpan<byte>(jsonUtf8Bytes);
            weatherForecast = JsonSerializer.Deserialize<WeatherForecast>(readOnlySpan);
            // </Deserialize1>
            weatherForecast.DisplayPropertyValues();

            // <Deserialize2>
            var utf8Reader = new Utf8JsonReader(jsonUtf8Bytes);
            weatherForecast = JsonSerializer.Deserialize<WeatherForecast>(ref utf8Reader);
            // </Deserialize2>
            weatherForecast.DisplayPropertyValues();
        }
    }
}
