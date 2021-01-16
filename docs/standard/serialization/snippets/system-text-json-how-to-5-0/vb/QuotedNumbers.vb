Imports System.Text.Json

Namespace QuotedNumbers

    Public Class Forecast
        Public Property [Date] As Date
        Public Property TemperatureC As Integer
        Public Property Summary As String
    End Class

    Public NotInheritable Class Program

        Public Shared Sub Main()
            Dim forecast1 As New Forecast

            Dim options As New JsonSerializerOptions

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
'Output JSON:
'{
'  "Date": "2020-10-23T12:27:06.4017385-07:00",
'  "TemperatureC": "40",
'  "Summary": "Hot"
'}
'Date: 10/23/2020 12:27:06 PM
'TemperatureC: 40
'Summary: Hot
