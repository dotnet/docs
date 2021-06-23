using System;
using System.Diagnostics;
using System.Text.Json;
using System.Text.Json.Node;
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
  }
}
");
            // Write JSON from a JsonNode
            var options = new JsonSerializerOptions { WriteIndented = true };
            Console.WriteLine(forecastNode.ToJsonString(options));

            // Get a JSON value from a JsonNode
            JsonNode temperatureCelsius = forecastNode["TemperatureCelsius"];
            Console.WriteLine($"temperatureCelsius Type={temperatureCelsius.GetType()}");
            Console.WriteLine($"temperatureCelsius JSON={temperatureCelsius.ToJsonString()}");

            // Get a typed value from a JsonNode
            int temperatureCelsiusInt = (int)forecastNode["TemperatureCelsius"];
            Console.WriteLine($"TemperatureCelsiusInt={temperatureCelsiusInt}");

            // Get a typed value from a JsonNode by using GetValue<T>
            temperatureCelsius = forecastNode["TemperatureCelsius"].GetValue<int>();
            Console.WriteLine($"TemperatureCelsiusInt={temperatureCelsiusInt}");

            // Get a JSON object from a JsonNode
            JsonNode temperatureRanges = forecastNode["TemperatureRanges"];
            Console.WriteLine($"temperatureRanges Type={temperatureRanges.GetType()}");
            Console.WriteLine($"temperatureRanges JSON={temperatureRanges.ToJsonString()}");

            // Get a JSON array from a JsonNode
            JsonNode datesAvailable = forecastNode["DatesAvailable"];
            Console.WriteLine($"datesAvailable Type={datesAvailable.GetType()}");
            Console.WriteLine($"datesAvailable JSON={datesAvailable.ToJsonString()}");

            // Get an array element value from a JsonArray
            JsonNode firstDateAvailable = datesAvailable[0];
            Console.WriteLine($"firstDateAvailable Type={firstDateAvailable.GetType()}");
            Console.WriteLine($"firstDateAvailable JSON={firstDateAvailable.ToJsonString()}");

            // Get a typed value by chaining references
            Console.WriteLine($"TemperatureRanges.Cold.High={forecastNode["TemperatureRanges"]["Cold"]["High"]}");


            // Parse a JSON array
            var datesNode = JsonNode.Parse(@"[""2019-08-01T00:00:00-07:00"",""2019-08-02T00:00:00-07:00""]");
            JsonNode firstDate = datesNode[0].GetValue<DateTimeOffset>();
            Console.WriteLine($"firstDate={ firstDate}");

            // Create a new JsonObject using object initializers and array params
            var forecastObject = new JsonObject
            {
                ["Date"] = new DateTime(2019, 8, 1),
                ["TemperatureCelsius"] = 25,
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

            // Add an object.
            forecastObject["TemperatureRanges"].AsObject().Add(
                "Hot", new JsonObject { ["High"] = 60, ["Low"] = 20 });

            // Remove an object.
            forecastObject.Remove("SummaryWords");

            // Change a value.
            forecastObject["Date"] = new DateTime(2019, 8, 3);

            // Get JSON that represents the new object.
            Console.WriteLine(forecastObject.ToJsonString(options));

        }
    }
}
// output:
//  {"Data":[0,1,2]}


