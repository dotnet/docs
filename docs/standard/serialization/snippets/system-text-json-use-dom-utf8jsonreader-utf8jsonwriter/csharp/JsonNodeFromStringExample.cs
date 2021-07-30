using System;
using System.Text.Json;
using System.Text.Json.Nodes;

namespace JsonNodeFromStringExample
{
    public class Program
    {
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
            // Create a JsonNode DOM from a JSON string.
            JsonNode forecastNode = JsonNode.Parse(jsonString);

            // Write JSON from a JsonNode
            var options = new JsonSerializerOptions { WriteIndented = true };
            Console.WriteLine(forecastNode.ToJsonString(options));
            // output:
            //{
            //  "Date": "2019-08-01T00:00:00",
            //  "Temperature": 25,
            //  "Summary": "Hot",
            //  "DatesAvailable": [
            //    "2019-08-01T00:00:00",
            //    "2019-08-02T00:00:00"
            //  ],
            //  "TemperatureRanges": {
            //    "Cold": {
            //      "High": 20,
            //      "Low": -10
            //    },
            //    "Hot": {
            //      "High": 60,
            //      "Low": 20
            //    }
            //  }
            //}

            // Get value from a JsonNode.
            JsonNode temperatureNode = forecastNode["Temperature"];
            Console.WriteLine($"Type={temperatureNode.GetType()}");
            Console.WriteLine($"JSON={temperatureNode.ToJsonString()}");
            //output:
            //Type = System.Text.Json.Nodes.JsonValue`1[System.Text.Json.JsonElement]
            //JSON = 25

            // Get a typed value from a JsonNode.
            int temperatureInt = (int)forecastNode["Temperature"];
            Console.WriteLine($"Value={temperatureInt}");
            //output:
            //Value=25

            // Get a typed value from a JsonNode by using GetValue<T>.
            temperatureInt = forecastNode["Temperature"].GetValue<int>();
            Console.WriteLine($"TemperatureInt={temperatureInt}");
            //output:
            //Value=25

            // Get a JSON object from a JsonNode.
            JsonNode temperatureRanges = forecastNode["TemperatureRanges"];
            Console.WriteLine($"Type={temperatureRanges.GetType()}");
            Console.WriteLine($"JSON={temperatureRanges.ToJsonString()}");
            //output:
            //Type = System.Text.Json.Nodes.JsonObject
            //JSON = { "Cold":{ "High":20,"Low":-10},"Hot":{ "High":60,"Low":20} }

            // Get a JSON array from a JsonNode.
            JsonNode datesAvailable = forecastNode["DatesAvailable"];
            Console.WriteLine($"Type={datesAvailable.GetType()}");
            Console.WriteLine($"JSON={datesAvailable.ToJsonString()}");
            //output:
            //datesAvailable Type = System.Text.Json.Nodes.JsonArray
            //datesAvailable JSON =["2019-08-01T00:00:00", "2019-08-02T00:00:00"]

            // Get an array element value from a JsonArray.
            JsonNode firstDateAvailable = datesAvailable[0];
            Console.WriteLine($"Type={firstDateAvailable.GetType()}");
            Console.WriteLine($"JSON={firstDateAvailable.ToJsonString()}");
            //output:
            //Type = System.Text.Json.Nodes.JsonValue`1[System.Text.Json.JsonElement]
            //JSON = "2019-08-01T00:00:00"

            // Get a typed value by chaining references.
            int coldHighTemperature = (int)forecastNode["TemperatureRanges"]["Cold"]["High"];
            Console.WriteLine($"TemperatureRanges.Cold.High={coldHighTemperature}");
            //output:
            //TemperatureRanges.Cold.High = 20

            // Parse a JSON array
            var datesNode = JsonNode.Parse(@"[""2019-08-01T00:00:00"",""2019-08-02T00:00:00""]");
            JsonNode firstDate = datesNode[0].GetValue<DateTime>();
            Console.WriteLine($"firstDate={ firstDate}");
            //output:
            //firstDate = "2019-08-01T00:00:00"
        }
    }
}
