Imports System
Imports System.Web
Imports System.Web.UI

Public Class Page1: Inherits Page

  Protected Sub Page_Load(sender As Object, e As EventArgs)
' <Snippet1>
Dim MyCookieCollection As HttpCookieCollection = Request.Cookies
 Dim MyCookie As HttpCookie = MyCookieCollection.Get("LastVisit")
 MyCookie.Value = DateTime.Now().ToString()
 MyCookieCollection.Set(MyCookie)
   
' </Snippet1>
 End Sub
End Class
