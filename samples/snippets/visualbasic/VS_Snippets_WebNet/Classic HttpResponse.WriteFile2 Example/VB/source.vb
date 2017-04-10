Imports System
Imports System.IO
Imports System.Web
Imports System.Web.UI

Public Class Page1: Inherits Page

  Protected Sub Page_Load(sender As Object, e As EventArgs)
' <Snippet1>
Dim FileName As String
 Dim MyFileInfo As FileInfo
 Dim StartPos, FileSize As Long
 
 FileName = "c:\\temp\\login.txt"
 MyFileInfo = New FileInfo(FileName)
 FileSize = MyFileInfo.Length 
 
 Response.Write("Please Login: <br>")
 Response.WriteFile(FileName, StartPos, FileSize)
    
' </Snippet1>
 End Sub
End Class
