Imports System
Imports System.Web
Imports System.Web.UI

Public Class Page1: Inherits Page

  Protected Sub Page_Load(sender As Object, e As EventArgs)
' <Snippet1>
Dim MyPostedMember As HttpPostedFile = Request.Files(0)
 Dim MyFileName As String = MyPostedMember.FileName
    
' </Snippet1>
 End Sub
End Class
