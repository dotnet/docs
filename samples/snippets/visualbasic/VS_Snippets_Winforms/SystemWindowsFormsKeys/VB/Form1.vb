'<Snippet1>
Public Class Form1

    Private Sub KeyDownWork(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) _
        Handles TextBox1.KeyDown

        MessageBox.Show(e.KeyCode, "KeyDown")

        MessageBox.Show(e.KeyCode.ToString(), "KeyDown")

        Dim kc As KeysConverter = New KeysConverter()
        MessageBox.Show(kc.ConvertToString(e.KeyCode), "KeyDown")
    End Sub


    Private Sub KeyPressWork(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) _
        Handles TextBox1.KeyPress

        MessageBox.Show(e.KeyChar, "KeyPress")
        MessageBox.Show(e.KeyChar.ToString(), "KeyPress")
    End Sub
End Class
'</Snippet1>
