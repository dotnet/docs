Imports System
Imports System.Web
Imports System.Web.UI
Imports System.Collections.Specialized

Public Class Page1: Inherits Page

  Protected Sub Page_Load(sender As Object, e As EventArgs)
' <Snippet1>
Dim loop1, loop2 As Integer
 Dim arr1(), arr2() As String
 Dim coll As NameValueCollection
 

' Load Header collection into NameValueCollection object.
coll=Request.Headers

' Put the names of all keys into a string array.
arr1 = coll.AllKeys 
For loop1 = 0 To arr1.GetUpperBound(0)
   Response.Write("Key: " & arr1(loop1) & "<br>")
   arr2 = coll.GetValues(loop1) 
   ' Get all values under this key.
   For loop2 = 0 To arr2.GetUpperBound(0)
      Response.Write("Value " & CStr(loop2) & ": " & Server.HtmlEncode(arr2(loop2)) & "<br>")
    Next loop2
 Next loop1
   
' </Snippet1>
 End Sub
End Class
