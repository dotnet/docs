
using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace NonPublicAccessors
{
    public class Forecast
    {
        public DateTime Date { get; private set; }
        public int TemperatureC { get; private set; }
        public string? Summary { get; private set; }
    };

    public class Program
    {
        public static void Main()
        {

            string forecastJson = "{\"Date\":\"2020-10-15T14:53:07.8281004-07:00\",\"TemperatureC\":40,\"Summary\":\"Hot1\"}";

            JsonSerializerOptions options = new()
            {
                IgnoreReadOnlyProperties = false
            };

            Forecast forecast = JsonSerializer.Deserialize<Forecast>(forecastJson, options);
            Console.WriteLine(forecast.Date);
            Console.WriteLine(forecast.TemperatureC);
            Console.WriteLine(forecast.Summary);
        }
    }
}
