﻿using System;
using System.Text.Json;

namespace RoundtripJsonElement
{
    public class WeatherForecast
    {
        public DateTimeOffset Date { get; set; }
        public int TemperatureCelsius { get; set; }
        public string Summary { get; set; }
        public JsonElement DatesAvailable { get; set; }
        public JsonElement SummaryWords { get; set; }
    }
        public class Program
    {
        public static void Main()
        {
            string jsonString =
@"{
  ""Date"": ""2019-08-01T00:00:00-07:00"",
  ""TemperatureCelsius"": 25,
  ""Summary"": ""Hot"",
  ""DatesAvailable"": [
    ""2019-08-01T00:00:00-07:00"",
    ""2019-08-02T00:00:00-07:00""
  ],
  ""SummaryWords"": [
    ""Cool"",
    ""Windy"",
    ""Humid""
  ]
}";
            WeatherForecast weatherForecast = 
                JsonSerializer.Deserialize<WeatherForecast>(jsonString);

            var serializeOptions = new JsonSerializerOptions { WriteIndented = true };
            jsonString = JsonSerializer.Serialize(weatherForecast, serializeOptions);
            Console.WriteLine($"JSON output:\n{jsonString}\n");
        }
    }
}
// output:
//JSON output:
//{
//  "Date": "2019-08-01T00:00:00-07:00",
//  "TemperatureCelsius": 25,
//  "Summary": "Hot",
//  "DatesAvailable": [
//    "2019-08-01T00:00:00-07:00",
//    "2019-08-02T00:00:00-07:00"
//  ],
//  "SummaryWords": [
//    "Cool",
//    "Windy",
//    "Humid"
//  ]
//}
