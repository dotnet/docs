Imports System.Text.Json
Imports System.Text.Json.Serialization

Namespace ImmutableTypes

    Public Structure Forecast
        Public ReadOnly Property [Date] As Date
        Public ReadOnly Property TemperatureC As Integer
        Public ReadOnly Property Summary As String

        <JsonConstructor>
        Public Sub New([Date] As Date, TemperatureC As Integer, Summary As String)
            Me.Date = [Date]
            Me.TemperatureC = TemperatureC
            Me.Summary = Summary
        End Sub

    End Structure

    Public NotInheritable Class Program

        Public Shared Sub Main()
            Dim json As String = "{""date"":""2020-09-06T11:31:01.923395-07:00"",""temperatureC"":-1,""summary"":""Cold""}"
            Console.WriteLine($"Input JSON: {json}")

            Dim forecast1 As Forecast = JsonSerializer.Deserialize(Of Forecast)(json, JsonSerializerOptions.Web)

            Console.WriteLine($"forecast.Date: {forecast1.[Date]}")
            Console.WriteLine($"forecast.TemperatureC: {forecast1.TemperatureC}")
            Console.WriteLine($"forecast.Summary: {forecast1.Summary}")

            Dim roundTrippedJson As String = JsonSerializer.Serialize(forecast1, JsonSerializerOptions.Web)

            Console.WriteLine($"Output JSON: {roundTrippedJson}")
        End Sub

    End Class

End Namespace

' Produces output like the following example:
'
'Input JSON: { "date":"2020-09-06T11:31:01.923395-07:00","temperatureC":-1,"summary":"Cold"}
'forecast.Date: 9 / 6 / 2020 11:31:01 AM
'forecast.TemperatureC: -1
'forecast.Summary: Cold
'Output JSON: { "date":"2020-09-06T11:31:01.923395-07:00","temperatureC":-1,"summary":"Cold"}
