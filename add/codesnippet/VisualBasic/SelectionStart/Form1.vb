'<Snippet1>
Public Class Form1

    Private Sub ButtonClickWork(ByVal sender As System.Object, ByVal e As System.EventArgs) _
        Handles Button1.Click

        Me.TextBox1.Text = "Hello world!"
        Me.TextBox1.ReadOnly = True

        Me.TextBox1.Focus()
        Me.TextBox1.SelectionStart = Me.TextBox1.SelectionStart + 1
        Me.TextBox1.SelectionLength = 1
    End Sub
End Class
'</Snippet1>
