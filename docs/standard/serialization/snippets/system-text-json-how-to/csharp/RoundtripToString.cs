using System;
using System.Collections.Generic;
using System.Text.Json;

namespace RoundtripToString1
{
    // <Serialize>
    public class Program
    {
        public class WeatherForecast
        {
            public DateTimeOffset Date { get; set; }
            public int TemperatureCelsius { get; set; }
            public string Summary { get; set; }
        }
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
    // output:
    //{"Date":"2019-08-01T00:00:00-07:00","TemperatureCelsius":25,"Summary":"Hot"}
    // </Serialize>
}

namespace RoundtripToString2
{
    // <SerializeWithGenericParameter>
    public class Program
    {
        public class WeatherForecast
        {
            public DateTimeOffset Date { get; set; }
            public int TemperatureCelsius { get; set; }
            public string Summary { get; set; }
        }
        public static void Main()
        {
            var weatherForecast = new WeatherForecast
            {
                Date = DateTime.Parse("2019-08-01"),
                TemperatureCelsius = 25,
                Summary = "Hot"
            };

            string jsonString = JsonSerializer.Serialize<WeatherForecast>(weatherForecast);
            Console.WriteLine(jsonString);
        }
    }
    // output:
    //{"Date":"2019-08-01T00:00:00-07:00","TemperatureCelsius":25,"Summary":"Hot"}
    // </SerializeWithGenericParameter>
}

namespace RoundtripToString3
{
    // <SerializePrettyPrint>
    public class Program
    {
        public class WeatherForecast
        {
            public DateTimeOffset Date { get; set; }
            public int TemperatureCelsius { get; set; }
            public string Summary { get; set; }
        }
        public static void Main()
        {
            var weatherForecast = new WeatherForecast
            {
                Date = DateTime.Parse("2019-08-01"),
                TemperatureCelsius = 25,
                Summary = "Hot"
            };

            var options = new JsonSerializerOptions { WriteIndented = true };
            string jsonString = JsonSerializer.Serialize(weatherForecast, options);
            Console.WriteLine(jsonString);
        }
    }
    // output:
    //{
    //  "Date": "2019-08-01T00:00:00-07:00",
    //  "TemperatureCelsius": 25,
    //  "Summary": "Hot"
    //}
    // </SerializePrettyPrint>
}
namespace RoundtripToString4
{
    // <SerializeExtra>
    public class Program
    {
        public class WeatherForecast
        {
            public DateTimeOffset Date { get; set; }
            public int TemperatureCelsius { get; set; }
            public string Summary { get; set; }
            public string SummaryField;
            public IList<DateTimeOffset> DatesAvailable { get; set; }
            public Dictionary<string, HighLowTemps> TemperatureRanges { get; set; }
            public string[] SummaryWords { get; set; }
        }

        public class HighLowTemps
        {
            public int High { get; set; }
            public int Low { get; set; }
        }
        public static void Main()
        {
            var weatherForecast = new WeatherForecast
            {
                Date = DateTime.Parse("2019-08-01"),
                TemperatureCelsius = 25,
                Summary = "Hot",
                SummaryField = "Hot",
                DatesAvailable = new List<DateTimeOffset>() 
                    { DateTime.Parse("2019-08-01"), DateTime.Parse("2019-08-02") },
                TemperatureRanges = new Dictionary<string, HighLowTemps>
                    {
                        { "Cold", new HighLowTemps { High = 20, Low = -10 } },
                        { "Hot", new HighLowTemps { High = 60 , Low = 20 } }
                    },
                SummaryWords = new string[] { "Cool", "Windy", "Humid" }
            };

            var options = new JsonSerializerOptions { WriteIndented = true };
            string jsonString = JsonSerializer.Serialize(weatherForecast, options);
            Console.WriteLine(jsonString);
        }
    }
    // output:
    //{
    //  "Date": "2019-08-01T00:00:00-07:00",
    //  "TemperatureCelsius": 25,
    //  "Summary": "Hot",
    //  "DatesAvailable": [
    //    "2019-08-01T00:00:00-07:00",
    //    "2019-08-02T00:00:00-07:00"
    //  ],
    //  "TemperatureRanges": {
    //    "Cold": {
    //      "High": 20,
    //      "Low": -10
    //    },
    //    "Hot": {
    //    "High": 60,
    //      "Low": 20
    //    }
    //  },
    //  "SummaryWords": [
    //    "Cool",
    //    "Windy",
    //    "Humid"
    //  ]
    //}
    // </SerializeExtra>
}

namespace RoundtripToString5
{
    // <Deserialize>
    public class Program
    {
        public record WeatherForecast
        {
            public DateTimeOffset Date { get; set; }
            public int TemperatureCelsius { get; set; }
            public string Summary { get; set; }
            public string SummaryField;
            public IList<DateTimeOffset> DatesAvailable { get; set; }
            public Dictionary<string, HighLowTemps> TemperatureRanges { get; set; }
            public string[] SummaryWords { get; set; }
        }

        public class HighLowTemps
        {
            public int High { get; set; }
            public int Low { get; set; }
        }
        public static void Main()
        {
            // <Deserialize>
            string jsonString =
@"{
  ""Date"": ""2019-08-01T00:00:00-07:00"",
  ""TemperatureCelsius"": 25,
  ""Summary"": ""Hot"",
  ""DatesAvailable"": [
    ""2019-08-01T00:00:00-07:00"",
    ""2019-08-02T00:00:00-07:00""
  ],
  ""TemperatureRanges"": {
                ""Cold"": {
                    ""High"": 20,
      ""Low"": -10
                },
    ""Hot"": {
                    ""High"": 60,
      ""Low"": 20
    }
            },
  ""SummaryWords"": [
    ""Cool"",
    ""Windy"",
    ""Humid""
  ]
}
";
                
            WeatherForecast weatherForecast = JsonSerializer.Deserialize<WeatherForecast>(jsonString);
            Console.WriteLine($"Date: {weatherForecast.Date}");
            Console.WriteLine($"TemperatureCelsius: {weatherForecast.TemperatureCelsius}");
            Console.WriteLine($"Summary: {weatherForecast.Summary}");
        }
    }
    // output:
    //Date: 8/1/2019 12:00:00 AM -07:00
    //TemperatureCelsius: 25
    //Summary: Hot
    // </Deserialize>
}
