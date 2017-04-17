Imports System
Imports System.Web
Imports System.Web.UI

Public Class Page1: Inherits Page

 Protected MyCookie As HttpCookie

  Protected Sub Page_Load(sender As Object, e As EventArgs)
 Dim MyCookieCollection As HttpCookieCollection
 MyCookieCollection = Request.Cookies
' <Snippet1>
MyCookie.Value = DateTime.Now().ToString()
 MyCookieCollection.Set(MyCookie)
    
' </Snippet1>
 End Sub
End Class
