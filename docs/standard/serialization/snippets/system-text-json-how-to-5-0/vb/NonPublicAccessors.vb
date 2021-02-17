Imports System.Text.Json
Imports System.Text.Json.Serialization

Namespace NonPublicAccessors

    Public Class Forecast
        Public Property [Date] As Date

        Private _temperatureC As Integer

        <JsonInclude>
        Public Property TemperatureC As Integer
            Get
                Return _temperatureC
            End Get
            Private Set(Value As Integer)
                _temperatureC = Value
            End Set
        End Property

        Private _summary As String

        <JsonInclude>
        Public Property Summary As String
            Private Get
                Return _summary
            End Get
            Set(Value As String)
                _summary = Value
            End Set
        End Property

    End Class

    Public NotInheritable Class Program

        Public Shared Sub Main()
            Dim json As String = "{""Date"":""2020-10-23T09:51:03.8702889-07:00"",""TemperatureC"":40,""Summary"":""Hot""}"
            Console.WriteLine($"Input JSON: {json}")

            Dim forecastDeserialized As Forecast = JsonSerializer.Deserialize(Of Forecast)(json)
            Console.WriteLine($"Date: {forecastDeserialized.[Date]}")
            Console.WriteLine($"TemperatureC: {forecastDeserialized.TemperatureC}")

            json = JsonSerializer.Serialize(forecastDeserialized)
            Console.WriteLine($"Output JSON: {json}")
        End Sub

    End Class

End Namespace

' Produces output like the following example:
'
'Input JSON: { "Date":"2020-10-23T09:51:03.8702889-07:00","TemperatureC":40,"Summary":"Hot"}
'Date: 10 / 23 / 2020 9:51:03 AM
'TemperatureC: 40
'Output JSON: { "Date":"2020-10-23T09:51:03.8702889-07:00","TemperatureC":40,"Summary":"Hot"}
