    Private Sub CellValidated(ByVal sender As Object, _
        ByVal e As DataGridViewCellEventArgs) _
        Handles DataGridView1.CellValidated

        ' Clear any error messages that may have been set in cell validation.
        DataGridView1.Rows(e.RowIndex).ErrorText = Nothing
    End Sub