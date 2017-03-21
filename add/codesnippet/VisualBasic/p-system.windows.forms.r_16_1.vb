    Private Sub AddMyText(ByVal textToAdd As String)
        ' Determine if the text to add is larger than the max length property.
        If textToAdd.Length > richTextBox1.MaxLength Then
            ' Alert user text is too large.
            MessageBox.Show("The text is too large to addo to the RichTextBox")
            ' Add the text to be added to the control.
        Else
            richTextBox1.SelectedText = textToAdd
        End If
    End Sub