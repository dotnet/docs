' <Snippet2>
Imports System

Partial Class MyCodeBehindVB
    Inherits System.Web.UI.Page


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        ' Place page-specific code here.

    End Sub

    ' Define a handler for the button click.
    Protected Sub SubmitBtn_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyButton.Click

        MySpan.InnerHtml = "Hello, " + MyTextBox.Text + "."

    End Sub

End Class
' </Snippet2>
