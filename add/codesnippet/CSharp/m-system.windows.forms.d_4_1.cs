    private void BindDataAndInitializeColumns()
    {
        dataGridView1.AutoGenerateColumns = true;
        dataGridView1.DataSource = customersDataSet;
        dataGridView1.Columns.Remove("Fax");
        dataGridView1.Columns["CustomerID"].Visible = false;
    }