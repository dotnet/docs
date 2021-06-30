using System;
using System.Diagnostics;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace JsonNodeExample
{
    public class Program
    {
        public static void Main()
        {
            // Parse a JSON object
            JsonNode forecastNode = JsonNode.Parse(
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
");
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

            // Get a JSON value from a JsonNode

            JsonNode temperature = forecastNode["Temperature"];
            Console.WriteLine($"Type={temperature.GetType()}");
            Console.WriteLine($"JSON={temperature.ToJsonString()}");
            //output:
            //Type = System.Text.Json.Node.JsonValue`1[System.Text.Json.JsonElement]
            //JSON = 25

            // Get a typed value from a JsonNode

            int temperatureInt = (int)forecastNode["Temperature"];
            Console.WriteLine($"Value={temperatureInt}");
            //output:
            //Value=25

            // Get a typed value from a JsonNode by using GetValue<T>

            temperature = forecastNode["Temperature"].GetValue<int>();
            Console.WriteLine($"TemperatureInt={temperatureInt}");
            //output:
            //Value=25

            // Get a JSON object from a JsonNode

            JsonNode temperatureRanges = forecastNode["TemperatureRanges"];
            Console.WriteLine($"Type={temperatureRanges.GetType()}");
            Console.WriteLine($"JSON={temperatureRanges.ToJsonString()}");
            //output:
            //Type = System.Text.Json.Node.JsonObject
            //JSON = { "Cold":{ "High":20,"Low":-10},"Hot":{ "High":60,"Low":20} }

            // Get a JSON array from a JsonNode

            JsonNode datesAvailable = forecastNode["DatesAvailable"];
            Console.WriteLine($"Type={datesAvailable.GetType()}");
            Console.WriteLine($"JSON={datesAvailable.ToJsonString()}");
            //output:
            //datesAvailable Type = System.Text.Json.Node.JsonArray
            //datesAvailable JSON =["2019-08-01T00:00:00", "2019-08-02T00:00:00"]

            // Get an array element value from a JsonArray

            JsonNode firstDateAvailable = datesAvailable[0];
            Console.WriteLine($"Type={firstDateAvailable.GetType()}");
            Console.WriteLine($"JSON={firstDateAvailable.ToJsonString()}");
            //output:
            //Type = System.Text.Json.Node.JsonValue`1[System.Text.Json.JsonElement]
            //JSON = "2019-08-01T00:00:00"

            // Get a typed value by chaining references

            Console.WriteLine($"TemperatureRanges.Cold.High={forecastNode["TemperatureRanges"]["Cold"]["High"]}");
            //output:
            //TemperatureRanges.Cold.High = 20

            // Parse a JSON array

            var datesNode = JsonNode.Parse(@"[""2019-08-01T00:00:00"",""2019-08-02T00:00:00""]");
            JsonNode firstDate = datesNode[0].GetValue<DateTime>();
            Console.WriteLine($"firstDate={ firstDate}");
            //output:
            //firstDate = "2019-08-01T00:00:00"

            // Create a new JsonObject using object initializers and array params.
            // Then add an object, remove an array, and change a value.

            var forecastObject = new JsonObject
            {
                ["Date"] = new DateTime(2019, 8, 1),
                ["Temperature"] = 25,
                ["Summary"] = "Hot",
                ["DatesAvailable"] = new JsonArray(new DateTime(2019, 8, 1), new DateTime(2019, 8, 2)),
                ["TemperatureRanges"] = new JsonObject
                {
                    ["Cold"] = new JsonObject
                    {
                        ["High"] = 20,
                        ["Low"] = -10
                    }
                },
                ["SummaryWords"] = new JsonArray("Cool", "Windy", "Humid")
            };

            forecastObject["TemperatureRanges"].AsObject().Add(
                "Hot", new JsonObject { ["High"] = 60, ["Low"] = 20 });
            forecastObject.Remove("SummaryWords");
            forecastObject["Date"] = new DateTime(2019, 8, 3);

            Console.WriteLine(forecastObject.ToJsonString(options));
            //output:
            //{
            //  "Date": "2019-08-03T00:00:00",
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
        }
    }
}


