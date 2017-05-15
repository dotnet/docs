Imports System
Imports System.Web
Imports System.Web.UI

Public Class Page1: Inherits Page

  Protected Sub Page_Load(sender As Object, e As EventArgs)
' <Snippet1>
Dim Loop1 As Integer
Dim StateVars(Application.Count) As String
 
For Loop1 = 0 To Application.Count -1
   StateVars(Loop1) = Application.GetKey(Loop1)
Next Loop1
' </Snippet1>
 End Sub
End Class
