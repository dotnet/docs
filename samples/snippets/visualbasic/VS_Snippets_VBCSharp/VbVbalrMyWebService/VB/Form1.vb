Option Explicit On
Option Strict On

Public Class Form1

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        MsgBox("98.6F is " & ConvertFromFahrenheitToCelsius(98.6) & "C")
    End Sub

    ' f188dc05-2c75-41b6-bb68-122d1c3110a2
    ' My.WebServices Object
    ' <snippet1>
    Function ConvertFromFahrenheitToCelsius(
        ByVal dFahrenheit As Double) As Double

        Return My.WebServices.TemperatureConverter.FahrenheitToCelsius(dFahrenheit)
    End Function
    ' </snippet1>

End Class


