Imports System
imports System.IO
Imports System.Web
Imports System.Web.UI

Public Class Page1: Inherits Page

  Protected Sub Page_Load(sender As Object, e As EventArgs)
' <Snippet1>
Dim EncodedString As String = "This is a &ltTest String&gt."
Dim writer As New StringWriter
Server.HtmlDecode(EncodedString, writer)
Dim DecodedString As String = writer.ToString()
   
' </Snippet1>
 End Sub
End Class
