
using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace OptionsDefaults
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

            JsonSerializerOptions options = new(JsonSerializerDefaults.Web)
            {
                WriteIndented = true
            };

            Console.WriteLine($"options.PropertyNameCaseInsensitive: {options.PropertyNameCaseInsensitive}");
            Console.WriteLine($"options.JsonNamingPolicy: {options.PropertyNamingPolicy}");

            string forecastJson = JsonSerializer.Serialize<Forecast>(forecast, options);
            Console.WriteLine($"Output JSON:\n{forecastJson}");

            Forecast forecastDeserialized = JsonSerializer.Deserialize<Forecast>(forecastJson, options);
            Console.WriteLine($"Date: {forecastDeserialized.Date}");
            Console.WriteLine($"TemperatureC: {forecastDeserialized.TemperatureC}");
            Console.WriteLine($"Summary: {forecastDeserialized.Summary}");
        }
    }
}
