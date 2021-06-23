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
            JsonNode jsonNode = JsonNode.Parse(
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
");
            // Write JSON from a JsonNode
            var options = new JsonSerializerOptions { WriteIndented = true };
            Console.WriteLine(jsonNode.ToJsonString(options));

            // Get a JSON value from a JsonNode
            JsonNode temperatureCelsius = jsonNode["TemperatureCelsius"];
            Console.WriteLine($"temperatureCelsius Type={temperatureCelsius.GetType()}");
            Console.WriteLine($"temperatureCelsius JSON={temperatureCelsius.ToJsonString()}");

            // Get a typed value from a JsonNode
            int temperatureCelsiusInt = (int)jsonNode["TemperatureCelsius"];
            Console.WriteLine($"TemperatureCelsiusInt={temperatureCelsiusInt}");

            // Get a typed value from a JsonNode by using GetValue<T>
            temperatureCelsius = jsonNode["TemperatureCelsius"].GetValue<int>();
            Console.WriteLine($"TemperatureCelsiusInt={temperatureCelsiusInt}");

            // Get a JSON object from a JsonNode
            JsonNode temperatureRanges = jsonNode["TemperatureRanges"];
            Console.WriteLine($"temperatureRanges Type={temperatureRanges.GetType()}");
            Console.WriteLine($"temperatureRanges JSON={temperatureRanges.ToJsonString()}");

            // Get a JSON array from a JsonNode
            JsonNode datesAvailable = jsonNode["DatesAvailable"];
            Console.WriteLine($"datesAvailable Type={datesAvailable.GetType()}");
            Console.WriteLine($"datesAvailable JSON={datesAvailable.ToJsonString()}");

            // Get an array element value from a JsonArray
            JsonNode firstDateAvailable = datesAvailable[0];
            Console.WriteLine($"firstDateAvailable Type={firstDateAvailable.GetType()}");
            Console.WriteLine($"firstDateAvailable JSON={firstDateAvailable.ToJsonString()}");

            // Get a typed value by chaining references
            Console.WriteLine($"TemperatureRanges.Cold.High={jsonNode["TemperatureRanges"]["Cold"]["High"]}");


            JsonNode jNode = JsonNode.Parse(@"{""MyProperty"":42}");
            int value = (int)jNode["MyProperty"];
            Debug.Assert(value == 42);
            // or
            value = jNode["MyProperty"].GetValue<int>();
            Debug.Assert(value == 42);

            // Parse a JSON array
            jNode = JsonNode.Parse("[10,11,12]");
            value = (int)jNode[1];
            Debug.Assert(value == 11);
            // or
            value = jNode[1].GetValue<int>();
            Debug.Assert(value == 11);

            // Create a new JsonObject using object initializers and array params
            var jObject = new JsonObject
            {
                ["MyChildObject"] = new JsonObject
                {
                    ["MyProperty"] = "Hello",
                    ["MyArray"] = new JsonArray(10, 11, 12)
                }
            };

            // Obtain the JSON from the new JsonObject
            string json = jObject.ToJsonString();
            Console.WriteLine(json); // {"MyChildObject":{"MyProperty":"Hello","MyArray":[10,11,12]}}

            // Indexers for property names and array elements are supported and can be chained
            Debug.Assert(jObject["MyChildObject"]["MyArray"][1].GetValue<int>() == 11);
        }
    }
}
// output:
//  {"Data":[0,1,2]}


