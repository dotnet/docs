using System;
using System.Text.Json;

namespace SystemTextJsonSamples
{
    public class RoundtripExtensionData
    {
        public static void Run()
        {
            string jsonString =
@"{
  ""Date"": ""2019-08-01T00:00:00-07:00"",
  ""temperatureCelsius"": 25,
  ""Summary"": ""Hot"",
  ""SummaryField"": ""Hot"",
  ""DatesAvailable"": [
    ""2019-08-01T00:00:00-07:00"",
    ""2019-08-02T00:00:00-07:00""
  ],
  ""TemperatureRanges"": {
    ""Cold"": {
      ""High"": {
        ""Celsius"": 20
      },
      ""Low"": {
        ""Celsius"": -10
      }
    },
    ""Hot"": {
      ""High"": {
        ""Celsius"": 60
      },
      ""Low"": {
        ""Celsius"": 20
      }
    }
  },
  ""SummaryWords"": [
    ""Cool"",
    ""Windy"",
    ""Humid""
  ]
}";
            Console.WriteLine($"JSON input:\n{jsonString}\n");

            // <SnippetDeserialize>
            WeatherForecastWithExtensionData weatherForecast = JsonSerializer.Deserialize<WeatherForecastWithExtensionData>(jsonString);
            weatherForecast.DisplayPropertyValues();
            // </SnippetDeserialize>

            // <SnippetSerialize>
            var serializeOptions = new JsonSerializerOptions
            {
                WriteIndented = true
            };
            jsonString = JsonSerializer.Serialize(weatherForecast, serializeOptions);
            // </SnippetSerialize>
            Console.WriteLine($"JSON output:\n{jsonString}\n");
        }
    }
}
