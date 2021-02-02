using System;
using System.IO;
using System.Text.Json;

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

            // <Serialize>
            jsonString = JsonSerializer.Serialize(weatherForecast);
            File.WriteAllText(fileName, jsonString);
            // </Serialize>
            Console.WriteLine($"The result is in {fileName}\n");

            // <Deserialize>
            jsonString = File.ReadAllText(fileName);
            weatherForecast = JsonSerializer.Deserialize<WeatherForecast>(jsonString);
            // </Deserialize>
            weatherForecast.DisplayPropertyValues();
        }
    }
}
