' Visual Basic .NET Document
Option Strict On

' <Snippet6>
Module Example2
    Public Sub Main()
        Dim byteValue As Byte = 12
        Console.WriteLine(Convert.ToBoolean(byteValue))
        Dim byteValue2 As Byte = 0
        Console.WriteLine(Convert.ToBoolean(byteValue2))
        Dim intValue As Integer = -16345
        Console.WriteLine(Convert.ToBoolean(intValue))
        Dim longValue As Long = 945
        Console.WriteLine(Convert.ToBoolean(longValue))
        Dim sbyteValue As SByte = -12
        Console.WriteLine(Convert.ToBoolean(sbyteValue))
        Dim dblValue As Double = 0
        Console.WriteLine(Convert.ToBoolean(dblValue))
        Dim sngValue As Single = 0.0001
        Console.WriteLine(Convert.ToBoolean(sngValue))
    End Sub
End Module
' The example displays the following output:
'       True
'       False
'       True
'       True
'       True
'       False
'       True
' </Snippet6>
