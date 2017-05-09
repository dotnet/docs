Imports System
Imports System.Web
Imports System.Web.UI

Public Class Page1: Inherits Page

  Protected Sub Page_Load(sender As Object, e As EventArgs)
' <Snippet1>
Dim AppState2 As HttpApplicationState
 
AppState2 = Application.Contents
 
Dim StateVars(AppState2.Count) As String
StateVars = AppState2.AllKeys

' </Snippet1>
 End Sub
End Class
