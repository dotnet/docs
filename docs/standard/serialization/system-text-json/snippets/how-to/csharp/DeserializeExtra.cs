using System.Text.Json;

namespace DeserializeExtra
{
    public class WeatherForecast
    {
        public DateTimeOffset Date { get; set; }
        public int TemperatureCelsius { get; set; }
        public string? Summary { get; set; }
        public string? SummaryField;
        public IList<DateTimeOffset>? DatesAvailable { get; set; }
        public Dictionary<string, HighLowTemps>? TemperatureRanges { get; set; }
        public string[]? SummaryWords { get; set; }
    }

    public class HighLowTemps
    {
        public int High { get; set; }
        public int Low { get; set; }
    }

    public class Program
    {
        public static void Main()
        {
            string jsonString =
                """
                {
                  "Date": "2019-08-01T00:00:00-07:00",
                  "TemperatureCelsius": 25,
                  "Summary": "Hot",
                  "DatesAvailable": [
                    "2019-08-01T00:00:00-07:00",
                    "2019-08-02T00:00:00-07:00"
                  ],
                  "TemperatureRanges": {
                    "Cold": {
                      "High": 20,
                      "Low": -10
                    },
                    "Hot": {
                      "High": 60,
                      "Low": 20
                    }
                  },
                  "SummaryWords": [
                    "Cool",
                    "Windy",
                    "Humid"
                  ]
                }
                """;
                
            WeatherForecast? weatherForecast = 
                JsonSerializer.Deserialize<WeatherForecast>(jsonString);

            Console.WriteLine($"Date: {weatherForecast?.Date}");
            Console.WriteLine($"TemperatureCelsius: {weatherForecast?.TemperatureCelsius}");
            Console.WriteLine($"Summary: {weatherForecast?.Summary}");

            if (weatherForecast?.DatesAvailable != null)
            {
                foreach (DateTimeOffset dateTimeOffset in weatherForecast.DatesAvailable)
                {
                    Console.WriteLine($"DateAvailable: {dateTimeOffset}");
                }
            }

            if (weatherForecast?.TemperatureRanges != null)
            {
                foreach (KeyValuePair<string, HighLowTemps> temperatureRange in weatherForecast.TemperatureRanges)
                {
                    Console.WriteLine($"TemperatureRange: {temperatureRange.Key}, {temperatureRange.Value.Low} - {temperatureRange.Value.High}");
                }
            }

            if (weatherForecast?.SummaryWords != null)
            {
                foreach (string summaryWord in weatherForecast.SummaryWords)
                {
                    Console.WriteLine($"SummaryWord: {summaryWord}");
                }
            }
        }
    }
}
// output:
//Date: 8/1/2019 12:00:00 AM -07:00
//TemperatureCelsius: 25
//Summary: Hot
//DateAvailable: 8/1/2019 12:00:00 AM -07:00
//DateAvailable: 8/2/2019 12:00:00 AM -07:00
//TemperatureRange: Cold, -10 - 20
//TemperatureRange: Hot, 20 - 60
//SummaryWord: Cool
//SummaryWord: Windy
//SummaryWord: Humid
