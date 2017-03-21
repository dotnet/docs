    Private Sub button1_Click(sender As Object, e As System.EventArgs)
        fontDialog1.ShowColor = True

        fontDialog1.Font = textBox1.Font
        fontDialog1.Color = textBox1.ForeColor

        If fontDialog1.ShowDialog() <> DialogResult.Cancel Then
            textBox1.Font = fontDialog1.Font
            textBox1.ForeColor = fontDialog1.Color
        End If
    End Sub 'button1_Click