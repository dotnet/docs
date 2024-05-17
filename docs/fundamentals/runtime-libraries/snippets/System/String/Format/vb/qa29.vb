' Visual Basic .NET Document
Option Strict On

' <Snippet29>
Module Example10
    Public Sub Main()
        Dim value As Integer = 1326
        Dim result As String = String.Format("{0,10:D6} {0,10:X8}", value)
        Console.WriteLine(result)
    End Sub
End Module
' The example displays the following output:
'       001326   0000052E
' </Snippet29>
