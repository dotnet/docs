using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace SerializeIgnoreCycles
{
    public class WeatherForecast
    {
        public DateTimeOffset Date { get; set; }
        public int TemperatureCelsius { get; set; }
        public string Summary { get; set; }
        public object NextDay { get; set; }
    }
    public class Program
    {
        public static void Main()
        {
            WeatherForecast weatherForecast = new WeatherForecast() 
                { Date = DateTimeOffset.UtcNow, TemperatureCelsius = 20, Summary = "Mild" };
            weatherForecast.NextDay = weatherForecast;

            var serializeOptions = new JsonSerializerOptions
            {
                WriteIndented = true,
                ReferenceHandler = ReferenceHandler.IgnoreCycles
            };
            string jsonString = JsonSerializer.Serialize(weatherForecast, serializeOptions);
            Console.WriteLine(jsonString);
        }
    }
}
// sample output:
//{
//  "Date": "2021-06-10T21:49:03.8612887+00:00",
//  "TemperatureCelsius": 20,
//  "Summary": "Mild",
//  "NextDay": null
//}
