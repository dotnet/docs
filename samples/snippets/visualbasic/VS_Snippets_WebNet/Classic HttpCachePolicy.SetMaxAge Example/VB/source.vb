Imports System
Imports System.Web
Imports System.Web.UI

Public Class Page1: Inherits Page

  Protected Sub Page_Load(sender As Object, e As EventArgs)
' <Snippet1>
Dim ts As New TimeSpan(0,30,0)
 Response.Cache.SetMaxAge(ts)
 
' </Snippet1>
 End Sub
End Class
