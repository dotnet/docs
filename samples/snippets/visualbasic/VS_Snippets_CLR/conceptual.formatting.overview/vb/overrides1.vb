' Visual Basic .NET Document
Option Strict On

' <Snippet2>
Public Class Temperature
    Private temp As Decimal

    Public Sub New(temperature As Decimal)
        Me.temp = temperature
    End Sub

    Public Overrides Function ToString() As String
        Return Me.temp.ToString("N1") + "°C"
    End Function
End Class

Module Example13
    Public Sub Main13()
        Dim currentTemperature As New Temperature(23.6D)
        Console.WriteLine("The current temperature is " +
                          currentTemperature.ToString())
    End Sub
End Module
' The example displays the following output:
'       The current temperature is 23.6°C.
' </Snippet2>
