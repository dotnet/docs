Imports System.Text.Json

Namespace OptionsDefaults

    Public Class Forecast
        Public Property [Date] As Date
        Public Property TemperatureC As Integer
        Public Property Summary As String
    End Class

    Public NotInheritable Class Program

        Public Shared Sub Main()
            Dim forecast1 As New Forecast() With {
                .[Date] = Date.Now,
                .TemperatureC = 40,
                .Summary = "Hot"
                }

            Dim options As New JsonSerializerOptions(JsonSerializerDefaults.Web) With {
                .WriteIndented = True
                }

            Console.WriteLine(
                $"PropertyNameCaseInsensitive: {options.PropertyNameCaseInsensitive}")
            Console.WriteLine(
                $"JsonNamingPolicy: {options.PropertyNamingPolicy}")
            Console.WriteLine(
                $"NumberHandling: {options.NumberHandling}")

            Dim forecastJson As String = JsonSerializer.Serialize(forecast1, options)
            Console.WriteLine($"Output JSON:{forecastJson}")

            Dim forecastDeserialized As Forecast = JsonSerializer.Deserialize(Of Forecast)(forecastJson, options)

            Console.WriteLine($"Date: {forecastDeserialized.[Date]}")
            Console.WriteLine($"TemperatureC: {forecastDeserialized.TemperatureC}")
            Console.WriteLine($"Summary: {forecastDeserialized.Summary}")
        End Sub

    End Class

End Namespace

' Produces output like the following example:
'
'PropertyNameCaseInsensitive: True
'JsonNamingPolicy: System.Text.Json.JsonCamelCaseNamingPolicy
'NumberHandling: AllowReadingFromString
'Output JSON:
'{
'  "date": "2020-10-21T15:40:06.9040831-07:00",
'  "temperatureC": 40,
'  "summary": "Hot"
'}
'Date: 10 / 21 / 2020 3:40:06 PM
'TemperatureC: 40
'Summary: Hot
