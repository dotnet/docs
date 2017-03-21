    private void ResetDataGridView()
    {
        dataGridView1.CancelEdit();
        dataGridView1.Columns.Clear();
        dataGridView1.DataSource = null;
        InitializeDataGridView();
    }