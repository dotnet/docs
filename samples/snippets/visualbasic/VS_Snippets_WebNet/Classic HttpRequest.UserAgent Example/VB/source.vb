Imports System
Imports System.Web
Imports System.Web.UI

Public Class Page1: Inherits Page

  Protected Sub Page_Load(sender As Object, e As EventArgs)
' <Snippet1>
Dim userAgent As String
 userAgent= Request.UserAgent
 If userAgent.IndexOf("MSIE 6.0") > -1 Then
    ' The browser is Microsoft Internet Explorer 6.0.
 End If
   
' </Snippet1>
 End Sub
End Class
