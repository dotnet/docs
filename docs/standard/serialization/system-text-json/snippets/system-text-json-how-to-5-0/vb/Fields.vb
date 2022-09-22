Imports System.Text.Json
Imports System.Text.Json.Serialization

Namespace Fields

    Public Class Forecast
        Public [Date] As Date
        Public TemperatureC As Integer
        Public Summary As String
    End Class

    Public Class Forecast2

        <JsonInclude>
        Public [Date] As Date

        <JsonInclude>
        Public TemperatureC As Integer

        <JsonInclude>
        Public Summary As String

    End Class

    Public NotInheritable Class Program

        Public Shared Sub Main()
            Dim json As String = "{""Date"":""2020-09-06T11:31:01.923395"",""TemperatureC"":-1,""Summary"":""Cold""}"
            Console.WriteLine($"Input JSON: {json}")

            Dim options As New JsonSerializerOptions With {
                .IncludeFields = True
            }
            Dim forecast1 As Forecast = JsonSerializer.Deserialize(Of Forecast)(json, options)

            Console.WriteLine($"forecast.Date: {forecast1.[Date]}")
            Console.WriteLine($"forecast.TemperatureC: {forecast1.TemperatureC}")
            Console.WriteLine($"forecast.Summary: {forecast1.Summary}")

            Dim roundTrippedJson As String = JsonSerializer.Serialize(forecast1, options)

            Console.WriteLine($"Output JSON: {roundTrippedJson}")

            Dim forecast21 As Forecast2 = JsonSerializer.Deserialize(Of Forecast2)(json)

            Console.WriteLine($"forecast2.Date: {forecast21.[Date]}")
            Console.WriteLine($"forecast2.TemperatureC: {forecast21.TemperatureC}")
            Console.WriteLine($"forecast2.Summary: {forecast21.Summary}")

            roundTrippedJson = JsonSerializer.Serialize(forecast21)

            Console.WriteLine($"Output JSON: {roundTrippedJson}")
        End Sub

    End Class

End Namespace

' Produces output like the following example:
'
'Input JSON: { "Date":"2020-09-06T11:31:01.923395","TemperatureC":-1,"Summary":"Cold"}
'forecast.Date: 9/6/2020 11:31:01 AM
'forecast.TemperatureC: -1
'forecast.Summary: Cold
'Output JSON: { "Date":"2020-09-06T11:31:01.923395","TemperatureC":-1,"Summary":"Cold"}
'forecast2.Date: 9/6/2020 11:31:01 AM
'forecast2.TemperatureC: -1
'forecast2.Summary: Cold
'Output JSON: { "Date":"2020-09-06T11:31:01.923395","TemperatureC":-1,"Summary":"Cold"}
