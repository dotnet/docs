Imports System
Imports System.Web
Imports System.Web.UI

Public Class Page1: Inherits Page

  Protected Sub Page_Load(sender As Object, e As EventArgs)
' <Snippet1>
Dim loop1 As Integer
 Dim MyCookie As HttpCookie
 Dim MyCookieCollection As HttpCookieCollection 
 
 MyCookieCollection = Request.Cookies
 
 For loop1 = 0 TO MyCookieCollection.Count - 1
    MyCookie = MyCookieCollection(loop1)
    If MyCookie.Name = "UserName" Then
       '...
    End If
 Next loop1
    
' </Snippet1>
 End Sub
End Class
