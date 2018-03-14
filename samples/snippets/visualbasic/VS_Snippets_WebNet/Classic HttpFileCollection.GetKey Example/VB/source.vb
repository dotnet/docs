Imports System
Imports System.Web
Imports System.Web.UI

Public Class Page1: Inherits Page

  Protected Sub Page_Load(sender As Object, e As EventArgs)
' <Snippet1>
Dim loop1 As Integer
 Dim MyFileColl As HttpFileCollection = Request.Files
 
 For loop1 = 0 To MyFileColl.Count - 1
    If MyFileColl.GetKey(loop1) = "CustInfo" Then
       '...
    End If
 Next loop1
    
' </Snippet1>
 End Sub
End Class
