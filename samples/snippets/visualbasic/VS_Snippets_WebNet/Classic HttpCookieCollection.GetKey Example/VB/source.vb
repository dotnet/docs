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
    If MyCookieCollection.GetKey(loop1) = "LastVisit" Then
       MyCookieCollection(loop1).Value = DateTime.Now().ToString()
       MyCookieCollection.Set(MyCookieCollection(loop1))
       Exit For
    End If
 Next loop1
    
' </Snippet1>
 End Sub
End Class
