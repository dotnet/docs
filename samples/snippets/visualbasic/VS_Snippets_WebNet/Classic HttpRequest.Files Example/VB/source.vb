Imports System
Imports System.Web
Imports System.Web.UI

Public Class Page1: Inherits Page

  Protected Sub Page_Load(sender As Object, e As EventArgs)
' <Snippet1>
Dim loop1 As Integer
 Dim arr1() As String
 Dim Files As HttpFileCollection
 
 Files = Request.Files ' Load File collection into HttpFileCollection variable.
 arr1 = Files.AllKeys ' This will get names of all files into a string array.
        For loop1 = 0 To arr1.GetUpperBound(0)
            Response.Write("File: " & Server.HtmlEncode(arr1(loop1)) & "<br>")
            Response.Write("  size = " + Files(loop1).ContentLength + "<br />")
            Response.Write("  content type = " + Files(loop1).ContentType + "<br />")
        Next loop1
' </Snippet1>
 End Sub
End Class
