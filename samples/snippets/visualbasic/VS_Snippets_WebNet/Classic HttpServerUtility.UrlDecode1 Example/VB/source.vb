Imports System
imports System.IO
Imports System.Web
Imports System.Web.UI

Public Class Page1: Inherits Page

 Protected EncodedString As String
  Protected Sub Page_Load(sender As Object, e As EventArgs)
' <Snippet1>
Dim writer As New StringWriter
Server.UrlDecode(EncodedString, writer)
Dim DecodedString As String = writer.ToString()
   
' </Snippet1>
 End Sub
End Class
