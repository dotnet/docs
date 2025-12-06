Imports System.Text.Json

Namespace DeserializeExtra

    Public Class WeatherForecast
        Public Property [Date] As DateTimeOffset
        Public Property TemperatureCelsius As Integer
        Public Property Summary As String
        Public SummaryField As String
        Public Property DatesAvailable As IList(Of DateTimeOffset)
        Public Property TemperatureRanges As Dictionary(Of String, HighLowTemps)
        Public Property SummaryWords As String()
    End Class

    Public Class HighLowTemps
        Public Property High As Integer
        Public Property Low As Integer
    End Class

    Public NotInheritable Class Program

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

            Dim weatherForecast As WeatherForecast =
                JsonSerializer.Deserialize(Of WeatherForecast)(jsonString)

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
                    Console.WriteLine($"TemperatureRange: {temperatureRange.Key} is {temperatureRange.Value.Low} to {temperatureRange.Value.High}")
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

' Output:
'
'Date: 8/1/2019 12:00:00 AM -07:00
'TemperatureCelsius: 25
'Summary: Hot
'DateAvailable: 8/1/2019 12:00:00 AM -07:00
'DateAvailable: 8/2/2019 12:00:00 AM -07:00
'TemperatureRange: Cold is -10 to 20
'TemperatureRange: Hot is 20 to 60
'SummaryWord: Cool
'SummaryWord: Windy
'SummaryWord: Humid
