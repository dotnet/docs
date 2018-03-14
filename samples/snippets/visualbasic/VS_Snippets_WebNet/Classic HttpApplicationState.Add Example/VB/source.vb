Imports System
Imports System.Web
Imports System.Web.UI

Public Class Page1: Inherits Page

 Protected MyObject1 as Object
 Protected MyObject2 as Object

Protected Sub Page_Load(sender As Object, e As EventArgs)
' <Snippet1>
Application.Add("MyAppVar1", MyObject1)
Application.Add("MyAppVar2", MyObject2)
' </Snippet1>
 End Sub
End Class
