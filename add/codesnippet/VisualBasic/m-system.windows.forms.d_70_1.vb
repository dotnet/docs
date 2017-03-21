        ' Check if the first row is selected.
        Private Sub button8_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button8.Click
            If myDataGrid.IsSelected(0) Then
                MessageBox.Show("Row selected", "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Else
                MessageBox.Show("Row not selected", "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If
        End Sub 'button8_Click

        ' Deselect the first row.
        Private Sub button11_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button11.Click
            myDataGrid.UnSelect(0)
        End Sub 'button11_Click
