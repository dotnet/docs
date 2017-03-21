    Private Sub dataGridView1_ColumnHeaderMouseClick( _
        ByVal sender As Object, ByVal e As DataGridViewCellMouseEventArgs) _
        Handles dataGridView1.ColumnHeaderMouseClick

        Me.dataGridView1.SelectionMode = _
            DataGridViewSelectionMode.ColumnHeaderSelect
        Me.dataGridView1.Columns(e.ColumnIndex).HeaderCell _
            .SortGlyphDirection = SortOrder.None
        Me.dataGridView1.Columns(e.ColumnIndex).Selected = True

    End Sub

    Private Sub dataGridView1_RowHeaderMouseClick( _
        ByVal sender As Object, ByVal e As DataGridViewCellMouseEventArgs) _
        Handles dataGridView1.RowHeaderMouseClick

        Me.dataGridView1.SelectionMode = _
            DataGridViewSelectionMode.RowHeaderSelect
        Me.dataGridView1.Rows(e.RowIndex).Selected = True

    End Sub