Imports System
Imports System.Web
Imports System.Web.UI


Public Class Page1
    Inherits Page
    
    Private Sub Page_Load(ByVal sender As [Object], ByVal e As EventArgs) 
' <Snippet1>
        Response.Write("Hello " & Server.HtmlEncode(Request.QueryString("UserName")) & "<br>")
' </Snippet1>    
    End Sub  
End Class 
