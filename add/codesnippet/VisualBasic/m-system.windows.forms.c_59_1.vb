    Private Sub button1_Click(sender As Object, e As System.EventArgs)
        ' Takes the selected text from a text box and puts it on the clipboard.
        If textBox1.SelectedText <> "" Then
            Clipboard.SetDataObject(textBox1.SelectedText, True)
        Else
            textBox2.Text = "No text selected in textBox1"
        End If
    End Sub 'button1_Click