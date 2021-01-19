Imports System.Text.Json

Namespace IgnoreValueDefaultOnSerialize

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

            Console.WriteLine(forecastJson)
        End Sub

    End Class

End Namespace

' Produces output like the following example:
'
'{ "Date":"2020-10-21T15:40:06.8920138-07:00"}
