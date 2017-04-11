Imports System
Imports System.Web
Imports System.Web.UI

Public Class Page1: Inherits Page

  Protected Sub Page_Load(sender As Object, e As EventArgs)
' <Snippet1>
Dim MyUrl As Uri = Request.UrlReferrer
 Response.Write("Referrer URL Port: " & Server.HtmlEncode(MyUrl.Port.ToString()) & "<br>")
 Response.Write("Referrer URL Protocol: " & Server.HtmlEncode(MyUrl.Scheme) & "<br>")
   
' </Snippet1>
 End Sub
End Class
