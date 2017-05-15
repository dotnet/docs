Imports System
Imports System.Web
Imports System.Web.UI

Public Class Page1: Inherits Page

  Protected Sub Page_Load(sender As Object, e As EventArgs)
' <Snippet1>
Dim Loop1 As Integer
 Dim MyFileCollection As HttpFileCollection = Request.Files
 
 For Loop1 = 0 To MyFileCollection.Count - 1
    If MyFileCollection(Loop1).ContentType = "video/mpeg" Then
       '...
    End If
 Next Loop1
    
' </Snippet1>
 End Sub
End Class
