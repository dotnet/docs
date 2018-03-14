' <snippet1>
Imports System
Imports System.IO

Public Class DeleteTest
    Public Shared Sub Main()
        ' Create a reference to a file.
        Dim fi As New FileInfo("temp.txt")
        ' Actually create the file.
        Dim fs As FileStream = fi.Create()
        ' Modify the file as required, and then close the file.
        fs.Close()
        ' Delete the file.
        fi.Delete()
    End Sub 'Main
End Class 'DeleteTest
' </snippet1>