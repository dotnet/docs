Imports System
imports System.IO
Imports System.Web
Imports System.Web.UI

Public Class Page1: Inherits Page

  Protected Sub Page_Load(sender As Object, e As EventArgs)
' <Snippet1>
Dim writer As New StringWriter
Server.Execute("Login.aspx", writer)
Response.Write("<H3>Please Login:</H3><br>" & writer.ToString())
   
' </Snippet1>
 End Sub
End Class
