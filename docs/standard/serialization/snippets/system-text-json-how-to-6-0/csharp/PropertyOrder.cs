using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace PropertyOrder
{
    public class WeatherForecast
    {
        [JsonPropertyOrder(1)]
        public DateTime Date { get; set; }
        public int TemperatureCelsius { get; set; }
        [JsonPropertyOrder(-1)]
        public string Summary { get; set; }
    }

    public class Program
    {
        public static void Main()
        {
            var weatherForecast = new WeatherForecast
            {
                Date = DateTime.Parse("2019-08-01"),
                TemperatureCelsius = 25,
                Summary = "Hot"
            };

            string jsonString = JsonSerializer.Serialize(weatherForecast);
            Console.WriteLine(jsonString);
        }
    }
}
// output:
//{"Summary":"Hot","TemperatureCelsius":25,"Date":"2019-08-01T00:00:00"}
