    Private Sub RemoveAnnotations(ByVal sender As Object, _
        ByVal args As DataGridViewCellEventArgs) _
        Handles songsDataGridView.RowValidated

        For Each cell As DataGridViewCell In _
            songsDataGridView.Rows(args.RowIndex).Cells
            cell.ErrorText = String.Empty
        Next

        For Each row As DataGridViewRow In songsDataGridView.Rows
            row.ErrorText = String.Empty
        Next

    End Sub