Imports System
Imports System.Web
Imports System.Web.UI

Public Class Page1: Inherits Page

  Protected MyNewObjectValue As Object

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
        ' <Snippet1>
        Application.Set("MyAppVar1", MyNewObjectValue)

        ' </Snippet1>
    End Sub
End Class
