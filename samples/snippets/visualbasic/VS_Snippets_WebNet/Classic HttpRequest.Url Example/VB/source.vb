Imports System
Imports System.Web
Imports System.Web.UI

Public Class Page1: Inherits Page

  Protected Sub Page_Load(sender As Object, e As EventArgs)
' <Snippet1>
Dim MyUrl As Uri = Request.Url
 Response.Write("URL Port: " & MyUrl.Port & "<br>")
 Response.Write("URL Protocol: " & Server.HtmlEncode(MyUrl.Scheme) & "<br>")

' </Snippet1>
 End Sub
End Class
