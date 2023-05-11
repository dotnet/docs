using System.Text.Json;
using System.Text.Json.Serialization;

namespace ImmutableTypesCtorParms
{
    public struct Forecast
    {
        public DateTime Date { get; }
        [JsonPropertyName("celsius")]
        public int TemperatureC { get; }
        public string Summary { get; }
 
        [JsonConstructor]
        public Forecast(DateTime date, int temperatureC, string summary) =>
            (Date, TemperatureC, Summary) = (date, temperatureC, summary);
    }

    public class Program
    {
        public static void Main()
        {
            var json = @"{""date"":""2020-09-06T11:31:01.923395-07:00"",""celsius"":-1,""summary"":""Cold""} ";
            Console.WriteLine($"Input JSON: {json}");

            var options = new JsonSerializerOptions(JsonSerializerDefaults.Web);

            var forecast = JsonSerializer.Deserialize<Forecast>(json, options);

            Console.WriteLine($"forecast.Date: {forecast.Date}");
            Console.WriteLine($"forecast.TemperatureC: {forecast.TemperatureC}");
            Console.WriteLine($"forecast.Summary: {forecast.Summary}");

            var roundTrippedJson =
                JsonSerializer.Serialize<Forecast>(forecast, options);

            Console.WriteLine($"Output JSON: {roundTrippedJson}");

        }
    }
}

// Produces output like the following example:
//
//Input JSON: { "date":"2020-09-06T11:31:01.923395-07:00","celsius":-1,"summary":"Cold"}
//forecast.Date: 9 / 6 / 2020 11:31:01 AM
//forecast.TemperatureC: -1
//forecast.Summary: Cold
//Output JSON: { "date":"2020-09-06T11:31:01.923395-07:00","celsius":-1,"summary":"Cold"}
