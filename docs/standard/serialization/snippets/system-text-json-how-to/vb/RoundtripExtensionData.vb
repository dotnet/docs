Imports System.Text.Json

Namespace SystemTextJsonSamples

    Public NotInheritable Class RoundtripExtensionData

        Public Shared Sub Run()
            Dim jsonString As String = "{
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
}"
            Console.WriteLine($"JSON input:{jsonString}")

            ' <Deserialize>
            Dim weatherForecast As WeatherForecastWithExtensionData = JsonSerializer.Deserialize(Of WeatherForecastWithExtensionData)(jsonString)
            weatherForecast.DisplayPropertyValues()
            ' </Deserialize>

            ' <Serialize>
            Dim serializeOptions As JsonSerializerOptions = New JsonSerializerOptions With {
                .WriteIndented = True
            }
            jsonString = JsonSerializer.Serialize(weatherForecast, serializeOptions)
            ' </Serialize>
            Console.WriteLine($"JSON output:{jsonString}")
        End Sub

    End Class

End Namespace
