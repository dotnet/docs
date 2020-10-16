
using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace CopyOptions
{
    public class Forecast
    {
        public DateTime Date { get; init; }
        public int TemperatureC { get; set; }
        public string Summary { get; set; }
    };

    public class Program
    {
        public static void Main()
        {
            Forecast forecast = new()
            {
                Date = DateTime.Now,
                TemperatureC = 40,
                Summary = "Hot"
            };

            JsonSerializerOptions options = new();
            JsonSerializerOptions optionsCopy = new(options)
            {
                WriteIndented = true
            };

            string forecastJson = JsonSerializer.Serialize<Forecast>(forecast, optionsCopy);
            Console.WriteLine($"Output JSON:\n{forecastJson}");
        }
    }
}
