    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        ' Sets the ShowApply property, then displays the dialog.
        FontDialog1.ShowApply = True
        FontDialog1.ShowDialog()

    End Sub

    Private Sub FontDialog1_Apply(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FontDialog1.Apply

        ' Applies the selected font to the selected text.
        RichTextBox1.SelectionFont = FontDialog1.Font

    End Sub