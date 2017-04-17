Imports System
Imports System.Web
Imports System.Web.UI

Public Class Page1: Inherits Page

  Protected Sub Page_Load(sender As Object, e As EventArgs)
' <Snippet1>
Dim loop1 As Integer
 Dim MyCookie As HttpCookie
 Dim MyCookieCollection As HttpCookieCollection = Request.Cookies
 
 For loop1 = 0 To MyCookieCollection.Count - 1
    MyCookie = MyCookieCollection.Get(loop1)
    If MyCookie.Name = "LastVisit" Then
       MyCookie.Value = DateTime.Now().ToString()
       MyCookieCollection.Set(MyCookie)
    End If
 Next loop1
   
' </Snippet1>
 End Sub
End Class
