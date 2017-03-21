    'Handles the Enter key being pressed while TextBox1 has focus. 
    Private Sub TextBox1_KeyDown(ByVal sender As Object, _
        ByVal e As KeyEventArgs) Handles TextBox1.KeyDown
        TextBox1.HideSelection = False
        If e.KeyCode = Keys.Enter Then
            e.Handled = True

            ' Copy the text from TextBox1 to RichTextBox1, add a CRLF after 
            ' the copied text, and keep the caret in view.
            RichTextBox1.SelectedText = TextBox1.Text + _
                Microsoft.VisualBasic.vbCrLf
            RichTextBox1.ScrollToCaret()
        End If
    End Sub