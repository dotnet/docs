' Visual Basic .NET Document
Option Strict On

Module Example14
    Public Sub Main14()
        ' <Snippet6>
        Dim byteValues() As Byte = {12, 163, 255}
        For Each byteValue As Byte In byteValues
            Console.WriteLine(byteValue.ToString("X4"))
        Next
        ' The example displays the following output:
        '       000C
        '       00A3
        '       00FF
        ' </Snippet6>
    End Sub
End Module

