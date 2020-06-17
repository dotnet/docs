' Visual Basic .NET Document
Option Strict On

' <Snippet2>
Public Module Example
    Dim rnd As Random

    Public Sub Main()
        rnd = New Random()
        Dim value As Double = MathLib.GetComputedValue(GetInt(), GetDouble())
        Console.WriteLine(value)
    End Sub

    Private Function GetInt() As Integer
        Return rnd.Next(11, 100)
    End Function

    Private Function GetDouble() As Double
        Return rnd.NextDouble()
    End Function
End Module
' </Snippet2>




Public Class MathLib
    Public Shared Function GetComputedValue(val1 As Integer, val2 As Double) As Double
        Return val1 * val2
    End Function
End Class
