Imports System
Imports System.Web
Imports System.Web.UI

Imports System.Collections.Specialized

Public Class Page1: Inherits Page

  Protected Sub Page_Load(sender As Object, e As EventArgs)
' <Snippet1>
Dim loop1 As Integer
Dim arr1() As String
Dim coll As NameValueCollection
 
' Load Form variables into NameValueCollection variable.
coll=Request.Form

' Get names of all forms into a string array.
arr1 = coll.AllKeys
For loop1 = 0 To arr1.GetUpperBound(0)
   Response.Write("Form: " & arr1(loop1) & "<br>")
Next loop1
   
' </Snippet1>
 End Sub
End Class
