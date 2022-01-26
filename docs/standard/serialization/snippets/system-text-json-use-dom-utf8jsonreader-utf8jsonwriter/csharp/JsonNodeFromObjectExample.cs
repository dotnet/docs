using System;
using System.Text.Json;
using System.Text.Json.Nodes;

namespace JsonNodeFromObjectExample
{
    public class Program
    {
        public static void Main()
        {
            // Create a new JsonObject using object initializers.
            var forecastObject = new JsonObject
            {
                ["Date"] = new DateTime(2019, 8, 1),
                ["Temperature"] = 25,
                ["Summary"] = "Hot",
                ["DatesAvailable"] = new JsonArray(
                    new DateTime(2019, 8, 1), new DateTime(2019, 8, 2)),
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
            forecastObject["TemperatureRanges"]["Hot"] =
                new JsonObject { ["High"] = 60, ["Low"] = 20 };

            // Remove a property.
            forecastObject.Remove("SummaryWords");

            // Change the value of a property.
            forecastObject["Date"] = new DateTime(2019, 8, 3);

            var options = new JsonSerializerOptions { WriteIndented = true };
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


