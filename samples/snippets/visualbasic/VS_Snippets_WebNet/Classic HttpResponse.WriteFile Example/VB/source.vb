Imports System
Imports System.Web
Imports System.Web.UI

Public Class Page1: Inherits Page

  Protected Sub Page_Load(sender As Object, e As EventArgs)
' <Snippet1>
Response.Write("Please Login: <br>")
 Response.WriteFile("login.txt")
    
' </Snippet1>
 End Sub
End Class
