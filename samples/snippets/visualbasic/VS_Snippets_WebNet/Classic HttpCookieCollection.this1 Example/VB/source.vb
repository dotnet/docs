Imports System
Imports System.Web
Imports System.Web.UI

Public Class Page1: Inherits Page

  Protected Sub Page_Load(sender As Object, e As EventArgs)
 Dim MyCookieCollection As HttpCookieCollection
 MyCookieCollection = Request.Cookies
' <Snippet1>
Dim CookieName As String = MyCookieCollection(0).Name
    
' </Snippet1>
 End Sub
End Class
