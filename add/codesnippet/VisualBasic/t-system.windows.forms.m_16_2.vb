    Private Sub Form1_FormClosing( _
        ByVal sender As System.Object, _
        ByVal e As System.Windows.Forms.FormClosingEventArgs) _
        Handles MyBase.FormClosing

        Dim message As String = _
                "Are you sure that you would like to close the form?"
        Dim caption As String = "Form Closing"
        Dim result = MessageBox.Show(message, caption, _
                                     MessageBoxButtons.YesNo, _
                                     MessageBoxIcon.Question)

        ' If the no button was pressed ...
        If (result = DialogResult.No) Then
            ' cancel the closure of the form.
            e.Cancel = True
        End If
    End Sub