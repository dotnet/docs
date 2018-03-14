Imports System
imports System.IO
Imports System.Web
Imports System.Web.UI

Public Class Page1: Inherits Page

  Protected Sub Page_Load(sender As Object, e As EventArgs)
' <Snippet1>
Dim TestString As String = "This is a <Test String>."
Dim writer As New StringWriter
Server.UrlEncode(TestString, writer)
Dim EncodedString As String = writer.ToString()
   
' </Snippet1>
 End Sub
End Class
