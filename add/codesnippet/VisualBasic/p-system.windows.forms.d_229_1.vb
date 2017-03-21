    Private Sub UserDeletingRow(ByVal sender As Object, _
        ByVal e As DataGridViewRowCancelEventArgs) _
        Handles DataGridView1.UserDeletingRow

        Dim startingBalanceRow As DataGridViewRow = DataGridView1.Rows(0)

        ' Check if the starting balance row is included in the selected rows
        If DataGridView1.SelectedRows.Contains(startingBalanceRow) Then
            ' Do not allow the user to delete the Starting Balance row.
            MessageBox.Show("Cannot delete Starting Balance row!")

            ' Cancel the deletion if the Starting Balance row is included.
            e.Cancel = True
        End If
    End Sub