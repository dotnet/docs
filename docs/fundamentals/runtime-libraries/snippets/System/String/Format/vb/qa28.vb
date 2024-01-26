'Visual Basic .NET Document

Option Strict On

' <Snippet28>
Module Example9
    Public Sub Main()
        Dim value As Integer = 16342
        Dim result As String = String.Format("{0,18:00000000} {0,18:00000000.000} {0,18:000,0000,000.0}",
                                           value)
        Console.WriteLine(result)
    End Sub
End Module
' The example displays the following output:
'           00016342       00016342.000    0,000,016,342.0
' </Snippet28>
