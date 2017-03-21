    Private Sub dataGridView1_CellStateChanged(ByVal sender As Object, _
        ByVal e As DataGridViewCellStateChangedEventArgs) _
        Handles dataGridView1.CellStateChanged

        Dim state As DataGridViewElementStates = e.StateChanged
        Dim msg As String = String.Format( _
            "Row {0}, Column {1}, {2}", _
            e.Cell.RowIndex, e.Cell.ColumnIndex, e.StateChanged)
        MessageBox.Show(msg, "Cell State Changed")

    End Sub