using System;
using System.Text.Json;

namespace Fields
{
    public class Forecast
    {
        public DateTime Date;
        public int TemperatureC;
        public string Summary;
    }
    public class Program
    {
        public static void Main()
        {
            var json = "{\"date\":\"2020-09-06T11:31:01.923395-07:00\",\"temperatureC\":-1,\"summary\":\"Cold\"} ";
            Console.WriteLine($"Input JSON: {json}");

            var options = new JsonSerializerOptions
                (JsonSerializerDefaults.Web)
            {
                IncludeFields = true,
            };
            var forecast = JsonSerializer.Deserialize<Forecast>
                (json, options);

            Console.WriteLine($"forecast.Date: {forecast.Date}");
            Console.WriteLine($"forecast.TemperatureC: {forecast.TemperatureC}");
            Console.WriteLine($"forecast.Summary: {forecast.Summary}");

            var roundTrippedJson = JsonSerializer.Serialize<Forecast>
                (forecast, options);
            Console.WriteLine($"Output JSON: {roundTrippedJson}");
        }
    }
}

// Produces output like the following example:
//
//Input JSON: { "date":"2020-09-06T11:31:01.923395-07:00","temperatureC":-1,"summary":"Cold"}
//forecast.Date: 9/6/2020 11:31:01 AM
//forecast.TemperatureC: -1
//forecast.Summary: Cold
//Output JSON: { "date":"2020-09-06T11:31:01.923395-07:00","temperatureC":-1,"summary":"Cold"}
