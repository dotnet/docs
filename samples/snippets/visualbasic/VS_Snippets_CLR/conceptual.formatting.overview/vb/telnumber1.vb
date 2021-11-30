' Visual Basic .NET Document
Option Strict On

' <Snippet21>
Module Example18
    Public Sub Main18()
        Dim number As Long = 8009999999
        Dim fmt As String = "000-000-0000"
        Console.WriteLine(number.ToString(fmt))
    End Sub
End Module
' The example displays the following output:

' The example displays the following output:
'       800-999-9999
' </Snippet21>
