' Visual Basic .NET Document
Option Strict On

' <Snippet1>
Module Example7
    Public Sub Main()
        Dim value1 As Double = 1.1632875981534209E-225
        Dim value2 As Double = 9.1642346778E-175
        Dim result As Double = value1 * value2
        Console.WriteLine("{0} * {1} = {2}", value1, value2, result)
        Console.WriteLine("{0} = 0: {1}", result, result.Equals(0.0))
    End Sub
End Module
' The example displays the following output:
'       1.16328759815342E-225 * 9.1642346778E-175 = 0
'       0 = 0: True
' </Snippet1>
