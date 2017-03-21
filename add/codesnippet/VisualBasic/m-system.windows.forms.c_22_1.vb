    Private Sub textBox1_Enter(sender As Object, e As System.EventArgs) Handles textBox1.Enter
        ' If the TextBox contains text, change its foreground and background colors.
        If textBox1.Text <> [String].Empty Then
            textBox1.ForeColor = Color.Red
            textBox1.BackColor = Color.Black
            ' Move the selection pointer to the end of the text of the control.
            textBox1.Select(textBox1.Text.Length, 0)
        End If
    End Sub 'textBox1_Enter
   
   
    Private Sub textBox1_Leave(sender As Object, e As System.EventArgs) Handles textBox1.Leave
        ' Reset the colors and selection of the TextBox after focus is lost.
        textBox1.ForeColor = Color.Black
        textBox1.BackColor = Color.White
        textBox1.Select(0, 0)
    End Sub 'textBox1_Leave
End Class 'Form1 