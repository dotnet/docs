' Visual Basic .NET Document
Option Strict On

' <Snippet1>
Module Example7
    Public Sub Main()
        Dim value1 As Single = 1.163287E-36
        Dim value2 As Single = 9.164234E-25
        Dim result As Single = value1 * value2
        Console.WriteLine("{0} * {1} = {2:R}", value1, value2, result)
        Console.WriteLine("{0} = 0: {1}", result, result.Equals(0))
    End Sub
End Module
' The example displays the following output:
'       1.163287E-36 * 9.164234E-25 = 0
'       0 = 0: True
' </Snippet1>
