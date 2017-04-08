Imports System
Imports System.Web
Imports System.Web.UI

Public Class Page1: Inherits Page

  Protected Sub Page_Load(sender As Object, e As EventArgs)
' <Snippet1>
Dim FileName As String
 FileName = "C:\Files\F1.txt"
 Response.AddFileDependency(FileName)
    
' </Snippet1>
 End Sub
End Class
