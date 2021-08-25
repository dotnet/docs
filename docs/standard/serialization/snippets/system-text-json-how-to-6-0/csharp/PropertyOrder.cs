using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace PropertyOrder
{
    public class WeatherForecast
    {
        [JsonPropertyOrder(-5)]
        public DateTime Date { get; set; }
        public int TemperatureC { get; set; }
        [JsonPropertyOrder(-2)]
        public int TemperatureF { get; set; }
        [JsonPropertyOrder(5)]
        public string Summary { get; set; }
        [JsonPropertyOrder(2)]
        public int WindSpeed { get; set; }
    }

    public class Program
    {
        public static void Main()
        {
            var weatherForecast = new WeatherForecast
            {
                Date = DateTime.Parse("2019-08-01"),
                TemperatureC = 25,
                TemperatureF = 25,
                Summary = "Hot",
                WindSpeed = 10
            };

            var options = new JsonSerializerOptions { WriteIndented = true };
            string jsonString = JsonSerializer.Serialize(weatherForecast, options);
            Console.WriteLine(jsonString);
        }
    }
}
// output:
//{
//  "Date": "2019-08-01T00:00:00",
//  "TemperatureF": 25,
//  "TemperatureC": 25,
//  "WindSpeed": 10,
//  "Summary": "Hot"
//}
