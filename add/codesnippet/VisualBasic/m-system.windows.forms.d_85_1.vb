    Private Sub ResetDataGridView()
        dataGridView1.CancelEdit()
        dataGridView1.Columns.Clear()
        dataGridView1.DataSource = Nothing
        InitializeDataGridView()
    End Sub