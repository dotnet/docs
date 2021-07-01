using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Nodes;

namespace JsonNodePOCOExample
{
    public class TemperatureRanges : Dictionary<string, HighLowTemps>
    {
    }

    public class HighLowTemps
    {
        public int High { get; set; }
        public int Low { get; set; }
    }
    public class Program
    {
        public static DateTime[] DatesAvailable { get; set; }

        public static void Main()
        {
            string jsonString =
 @"{
  ""Date"": ""2019-08-01T00:00:00"",
  ""Temperature"": 25,
  ""Summary"": ""Hot"",
  ""DatesAvailable"": [
    ""2019-08-01T00:00:00"",
    ""2019-08-02T00:00:00""
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
  }
}
";
            // Parse all of the JSON.
            JsonNode forecastNode = JsonNode.Parse(jsonString);

            // Get a subsection and deserialize it into a custom type.
            JsonNode trNode = forecastNode["TemperatureRanges"];
            TemperatureRanges tr = JsonSerializer.Deserialize<TemperatureRanges>(trNode.ToJsonString());
            Console.WriteLine($"Cold.Low={tr["Cold"].Low}, Hot.High={tr["Hot"].High}");
            // output:
            //Cold.Low=-10, Hot.High=60

            // Get a subsection and deserialize it into an array.
            JsonNode daNode = forecastNode["DatesAvailable"];
            DatesAvailable = (JsonSerializer.Deserialize<DateTime[]>(daNode.ToJsonString()));
            Console.WriteLine($"DatesAvailable[0]={DatesAvailable[0]}");
            // output:
            //DatesAvailable[0]=8/1/2019 12:00:00 AM
        }
    }
}


