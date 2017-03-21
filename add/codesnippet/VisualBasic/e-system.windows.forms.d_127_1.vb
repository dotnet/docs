    Private Sub dataGridView1_CellEnter(ByVal sender As Object, _
        ByVal e As DataGridViewCellEventArgs) _
        Handles dataGridView1.CellEnter

        dataGridView1(e.ColumnIndex, e.RowIndex).Style _
            .SelectionBackColor = Color.Blue

    End Sub

    Private Sub dataGridView1_CellLeave(ByVal sender As Object, _
        ByVal e As DataGridViewCellEventArgs) _
        Handles dataGridView1.CellLeave

        dataGridView1(e.ColumnIndex, e.RowIndex).Style _
            .SelectionBackColor = Color.Empty

    End Sub