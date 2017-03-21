    ' Forces the control to repaint itself when the user 
    ' manually changes the width of a column.
    Sub dataGridView1_ColumnWidthChanged(ByVal sender As Object, _
        ByVal e As DataGridViewColumnEventArgs) _
        Handles dataGridView1.ColumnWidthChanged

        Me.dataGridView1.Invalidate()

    End Sub 'dataGridView1_ColumnWidthChanged