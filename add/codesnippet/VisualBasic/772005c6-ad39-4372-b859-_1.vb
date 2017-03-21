    Private Sub CopyPasteButton_Click(ByVal sender As Object, _
        ByVal e As System.EventArgs) Handles CopyPasteButton.Click

        If Me.DataGridView1.GetCellCount( _
            DataGridViewElementStates.Selected) > 0 Then

            Try

                ' Add the selection to the clipboard.
                Clipboard.SetDataObject( _
                    Me.DataGridView1.GetClipboardContent())

                ' Replace the text box contents with the clipboard text.
                Me.TextBox1.Text = Clipboard.GetText()

            Catch ex As System.Runtime.InteropServices.ExternalException
                Me.TextBox1.Text = _
                    "The Clipboard could not be accessed. Please try again."
            End Try

        End If

    End Sub