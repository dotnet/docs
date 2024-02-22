' Visual Basic .NET Document
Option Strict On

' <Snippet11>
Module Example3
    Public Sub Main()
        Dim value1 As Double = 0.333333333333333
        Dim value2 As Double = 1 / 3
        Dim precision As Integer = 7
        value1 = Math.Round(value1, precision)
        value2 = Math.Round(value2, precision)
        Console.WriteLine("{0:R} = {1:R}: {2}", value1, value2, value1.Equals(value2))
    End Sub
End Module
' The example displays the following output:
'       0.3333333 = 0.3333333: True
' </Snippet11>

