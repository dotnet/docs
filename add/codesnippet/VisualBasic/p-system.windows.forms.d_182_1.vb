    ' AutoSize the third column.
    Private Sub Button6_Click(ByVal sender As Object, _
        ByVal e As System.EventArgs) Handles Button6.Click

        Dim column As DataGridViewColumn = dataGridView.Columns(2)
        column.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
    End Sub