Imports System
Imports System.Web
Imports System.Web.UI

Public Class Page1: Inherits Page

  Protected Sub Page_Load(sender As Object, e As EventArgs)
' <Snippet1>
Dim userLang() As String
 Dim count As Integer
 
 userLang = Request.UserLanguages
 For count = 0 To userLang.GetUpperBound(0)
    Response.Write("User Language: " & Cstr(userLang(count)) & "<br>")
 Next count
   
' </Snippet1>
 End Sub
End Class
