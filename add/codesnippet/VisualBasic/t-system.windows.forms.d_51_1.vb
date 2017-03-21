    Private Sub dataGridView1_UserDeletingRow(ByVal sender As Object, _
        ByVal e As System.Windows.Forms.DataGridViewRowCancelEventArgs) _
        Handles dataGridView1.UserDeletingRow

        If e.Row.Index < Me.customers.Count Then

            ' If the user has deleted an existing row, remove the 
            ' corresponding Customer object from the data store.
            Me.customers.RemoveAt(e.Row.Index)

        End If

        If e.Row.Index = Me.rowInEdit Then

            ' If the user has deleted a newly created row, release
            ' the corresponding Customer object. 
            Me.rowInEdit = -1
            Me.customerInEdit = Nothing

        End If

    End Sub