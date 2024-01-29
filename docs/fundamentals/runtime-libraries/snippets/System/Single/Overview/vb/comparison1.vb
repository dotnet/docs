' Visual Basic .NET Document
Option Strict On

' <Snippet9>
Module Example1
    Public Sub Main()
        Dim value1 As Single = 0.3333333
        Dim value2 As Single = 1 / 3
        Console.WriteLine("{0:R} = {1:R}: {2}", value1, value2, value1.Equals(value2))
    End Sub
End Module
' The example displays the following output:
'       0.3333333 = 0.333333343: False
' </Snippet9>

