Imports System
Imports System.Web
Imports System.Web.UI

Public Class Page1: Inherits Page

  Protected Sub Page_Load(sender As Object, e As EventArgs)
' <Snippet1>
' Create the one-dimensional target array.
 ' Dimension it large enough to hold the cookies collection.
 Dim MyArray As Array = Array.CreateInstance(GetType(String), Request.Cookies.Count)
 
 ' Copy the entire collection to the array.
 Request.Cookies.CopyTo(MyArray, 0)
    
' </Snippet1>
 End Sub
End Class
