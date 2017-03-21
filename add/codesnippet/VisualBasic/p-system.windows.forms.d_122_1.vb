    Private Sub dataGridView1_CellBeginEdit(ByVal sender As Object, _
        ByVal e As DataGridViewCellCancelEventArgs) _
        Handles DataGridView1.CellBeginEdit

        Dim msg As String = _
            String.Format("Editing Cell at ({0}, {1})", _
            e.ColumnIndex, e.RowIndex)
        Me.Text = msg

    End Sub

    Private Sub dataGridView1_CellEndEdit(ByVal sender As Object, _
        ByVal e As DataGridViewCellEventArgs) _
        Handles DataGridView1.CellEndEdit

        Dim msg As String = _
            String.Format("Finished Editing Cell at ({0}, {1})", _
            e.ColumnIndex, e.RowIndex)
        Me.Text = msg

    End Sub