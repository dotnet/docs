' Visual Basic .NET Document
Option Strict On

Public Enum ArrivalStatus6 As Integer
    Unknown = -3
    Late = -1
    OnTime = 0
    Early = 1
End Enum

Module Example6
    Public Sub Main()
        ' <Snippet10>
        Dim formats() As String = {"G", "F", "D", "X"}
        Dim status As ArrivalStatus6 = ArrivalStatus6.Late
        For Each fmt As String In formats
            Console.WriteLine(status.ToString(fmt))
        Next
        ' The example displays the following output:
        '       Late
        '       Late
        '       -1
        '       FFFFFFFF
        ' </Snippet10>
    End Sub
End Module

