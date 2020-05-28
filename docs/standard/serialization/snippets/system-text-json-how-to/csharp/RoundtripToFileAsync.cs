using System;
using System.IO;
using System.Text;
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

            // <SnippetSerialize>
            using (FileStream fs = File.Create(fileName))
            {
                await JsonSerializer.SerializeAsync(fs, weatherForecast);
            }
            // </SnippetSerialize>
            Console.WriteLine($"The result is in {fileName}\n");

            // <SnippetDeserialize>
            using (FileStream fs = File.OpenRead(fileName))
            {
                weatherForecast = await JsonSerializer.DeserializeAsync<WeatherForecast>(fs);
            }
            // </SnippetDeserialize>
            weatherForecast.DisplayPropertyValues();
        }
    }
}
