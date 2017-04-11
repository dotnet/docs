Imports System
Imports System.Web
Imports System.Web.UI

Public Class Page1: Inherits Page

  Protected Sub Page_Load(sender As Object, e As EventArgs)
' <Snippet1>
Dim MyCookie As HttpCookie = New HttpCookie("Cookie1")
 MyCookie.Values("Val1") = "1"
 MyCookie.Values("Val2") = "2"
 MyCookie.Values("Val3") = "3"
 Response.Cookies.Add(MyCookie)
    
' </Snippet1>
 End Sub
End Class
