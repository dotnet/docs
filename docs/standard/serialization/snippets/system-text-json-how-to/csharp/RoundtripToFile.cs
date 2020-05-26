using System;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace SystemTextJsonSamples
{
    public class RoundtripToFile
    {
        public static void Run()
        {
            string jsonString;
            string fileName = "WeatherForecast.json";
            WeatherForecast weatherForecast = WeatherForecastFactories.CreateWeatherForecast();
            weatherForecast.DisplayPropertyValues();

            // <SnippetSerialize>
            jsonString = JsonSerializer.Serialize(weatherForecast);
            File.WriteAllText(fileName, jsonString);
            // </SnippetSerialize>
            Console.WriteLine($"The result is in {fileName}\n");

            // <SnippetDeserialize>
            jsonString = File.ReadAllText(fileName);
            weatherForecast = JsonSerializer.Deserialize<WeatherForecast>(jsonString);
            // </SnippetDeserialize>
            weatherForecast.DisplayPropertyValues();
        }
    }
}
