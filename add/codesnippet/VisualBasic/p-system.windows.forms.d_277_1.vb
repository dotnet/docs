    'Set the minimum width.
    Private Sub Button4_Click(ByVal sender As Object, _
        ByVal e As System.EventArgs) Handles Button4.Click

        Dim column As DataGridViewColumn = dataGridView.Columns(1)
        column.MinimumWidth = 40
    End Sub