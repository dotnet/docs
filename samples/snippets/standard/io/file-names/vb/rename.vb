Imports System.IO

Module Example3
    Public Sub Main()
        Dim fi As New FileInfo(".\test.txt")
        fi.MoveTo(".\Test.txt")
    End Sub
End Module
