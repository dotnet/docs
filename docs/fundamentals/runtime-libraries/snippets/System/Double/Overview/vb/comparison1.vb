' Visual Basic .NET Document
Option Strict On

' <Snippet9>
Module Example1
    Public Sub Main()
        Dim value1 As Double = 0.333333333333333
        Dim value2 As Double = 1 / 3
        Console.WriteLine("{0:R} = {1:R}: {2}", value1, value2, value1.Equals(value2))
    End Sub
End Module
' The example displays the following output:
'       0.333333333333333 = 0.33333333333333331: False
' </Snippet9>

