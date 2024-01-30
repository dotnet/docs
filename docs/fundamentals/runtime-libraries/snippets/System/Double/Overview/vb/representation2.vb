' Visual Basic .NET Document
Option Strict On

' <Snippet4>
Module Example15
    Public Sub Main()
        Dim value As Double = 123456789012.34567
        Dim additional As Double = Double.Epsilon * 1.0E+15
        Console.WriteLine("{0} + {1} = {2}", value, additional,
                                           value + additional)
    End Sub
End Module
' The example displays the following output:
'   123456789012.346 + 4.94065645841247E-309 = 123456789012.346
' </Snippet4>

