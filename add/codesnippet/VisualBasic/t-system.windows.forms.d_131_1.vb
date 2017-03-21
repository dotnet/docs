    Private Sub dataGridView1_RowsAdded(ByVal sender As Object, _
        ByVal e As DataGridViewRowsAddedEventArgs) _
        Handles dataGridView1.RowsAdded

        If newRowNeeded Then
            newRowNeeded = False
            numberOfRows = numberOfRows + 1
        End If
    End Sub