' Visual Basic .NET Document
Option Strict On

' <Snippet2>
Module Example8
    Public Sub Main()
        Dim value1 As Single = 3.065E+35
        Dim value2 As Single = 6.9375E+32
        Dim result As Single = value1 * value2
        Console.WriteLine("PositiveInfinity: {0}",
                         Single.IsPositiveInfinity(result))
        Console.WriteLine("NegativeInfinity: {0}",
                        Single.IsNegativeInfinity(result))
        Console.WriteLine()
        value1 = -value1
        result = value1 * value2
        Console.WriteLine("PositiveInfinity: {0}",
                         Single.IsPositiveInfinity(result))
        Console.WriteLine("NegativeInfinity: {0}",
                        Single.IsNegativeInfinity(result))
    End Sub
End Module
' The example displays the following output:
'       PositiveInfinity: True
'       NegativeInfinity: False
'       
'       PositiveInfinity: False
'       NegativeInfinity: True
' </Snippet2>
