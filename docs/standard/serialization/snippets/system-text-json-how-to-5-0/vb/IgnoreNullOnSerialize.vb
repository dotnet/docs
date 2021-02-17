Imports System.Text.Json

Namespace IgnoreNullOnSerialize

    Public Class Forecast
        Public Property [Date] As Date
        Public Property TemperatureC As Integer
        Public Property Summary As String
    End Class

    Public NotInheritable Class Program

        Public Shared Sub Main()
            Dim forecast1 As New Forecast() With
            {
            .[Date] = Date.Now,
            .Summary = Nothing,
            .TemperatureC = CType(Nothing, Integer)
            }

            Dim options As New JsonSerializerOptions

            Dim forecastJson As String = JsonSerializer.Serialize(forecast1, options)

            Console.WriteLine(forecastJson)
        End Sub

    End Class

End Namespace

' Produces output like the following example:
'
'{"Date":"2020-10-30T10:11:40.2359135-07:00","TemperatureC":0}
