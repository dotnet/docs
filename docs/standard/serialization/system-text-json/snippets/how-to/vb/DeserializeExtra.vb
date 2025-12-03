Imports System.Text.Json

Namespace SystemTextJsonSamples

    Public NotInheritable Class DeserializeExtra

        Public Shared Sub Run()
            Dim jsonString As String =
                "{
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
                }"

            Dim weatherForecast As WeatherForecastWithPOCOs =
                JsonSerializer.Deserialize(Of WeatherForecastWithPOCOs)(jsonString)

            Console.WriteLine($"Date: {weatherForecast?.Date}")
            Console.WriteLine($"TemperatureCelsius: {weatherForecast?.TemperatureCelsius}")
            Console.WriteLine($"Summary: {weatherForecast?.Summary}")

            If weatherForecast?.DatesAvailable IsNot Nothing Then
                For Each dateTimeOffset As DateTimeOffset In weatherForecast.DatesAvailable
                    Console.WriteLine($"DateAvailable: {dateTimeOffset}")
                Next
            End If

            If weatherForecast?.TemperatureRanges IsNot Nothing Then
                For Each temperatureRange As KeyValuePair(Of String, HighLowTemps) In weatherForecast.TemperatureRanges
                    Console.WriteLine($"TemperatureRange: {temperatureRange.Key}, {temperatureRange.Value.Low} - {temperatureRange.Value.High}")
                Next
            End If

            If weatherForecast?.SummaryWords IsNot Nothing Then
                For Each summaryWord As String In weatherForecast.SummaryWords
                    Console.WriteLine($"SummaryWord: {summaryWord}")
                Next
            End If
        End Sub

    End Class

End Namespace
' output:
'Date: 8/1/2019 12:00:00 AM -07:00
'TemperatureCelsius: 25
'Summary: Hot
'DateAvailable: 8/1/2019 12:00:00 AM -07:00
'DateAvailable: 8/2/2019 12:00:00 AM -07:00
'TemperatureRange: Cold, -10 - 20
'TemperatureRange: Hot, 20 - 60
'SummaryWord: Cool
'SummaryWord: Windy
'SummaryWord: Humid
