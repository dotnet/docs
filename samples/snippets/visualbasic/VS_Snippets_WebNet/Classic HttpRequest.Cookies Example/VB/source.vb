Imports System
Imports System.Web
Imports System.Web.UI

Public Class Page1: Inherits Page

  Protected Sub Page_Load(sender As Object, e As EventArgs)
' <Snippet1>
 Dim loop1, loop2 As Integer
 Dim arr1(), arr2() As String
 Dim MyCookieColl As HttpCookieCollection 
 Dim MyCookie As HttpCookie
 
 MyCookieColl = Request.Cookies
 ' Capture all cookie names into a string array.
 arr1 = MyCookieColl.AllKeys
 ' Grab individual cookie objects by cookie name     
 for loop1 = 0 To arr1.GetUpperBound(0)
    MyCookie = MyCookieColl(arr1(loop1))
    Response.Write("Cookie: " & MyCookie.Name & "<br>")
            Response.Write("Secure:" & MyCookie.Secure & "<br>")
 
    ' Grab all values for single cookie into an object array.
    arr2 = MyCookie.Values.AllKeys
    ' Loop through cookie value collection and print all values.
    for loop2 = 0 To arr2.GetUpperBound(0)
       Response.Write("Value " & CStr(loop2) + ": " & Server.HtmlEncode(arr2(loop2)) & "<br>")
    Next loop2
 Next loop1
   
' </Snippet1>
 End Sub
End Class
