using System;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;

namespace SystemTextJsonSamples
{
    public class RoundtripToFileAsync
    {
        public static async Task RunAsync()
        {
            string fileName = "WeatherForecastAsync.json";
            WeatherForecast weatherForecast = WeatherForecastFactories.CreateWeatherForecast();
            weatherForecast.DisplayPropertyValues();

            // <Serialize>
            using FileStream createStream = File.Create(fileName);
            await JsonSerializer.SerializeAsync(createStream, weatherForecast);
            // </Serialize>
            Console.WriteLine($"The result is in {fileName}\n");
            await createStream.DisposeAsync();

            // <Deserialize>
            using FileStream openStream = File.OpenRead(fileName);
            weatherForecast = await JsonSerializer.DeserializeAsync<WeatherForecast>(openStream);
            // </Deserialize>
            weatherForecast.DisplayPropertyValues();
        }
    }
}
