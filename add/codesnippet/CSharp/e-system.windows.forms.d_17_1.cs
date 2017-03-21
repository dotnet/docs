    private void dataGridView1_DataBindingComplete(object sender,
        DataGridViewBindingCompleteEventArgs e)
    {
        // Hide some of the columns.
        dataGridView1.Columns["EmployeeID"].Visible = false;
        dataGridView1.Columns["Address"].Visible = false;
        dataGridView1.Columns["TitleOfCourtesy"].Visible = false;
        dataGridView1.Columns["BirthDate"].Visible = false;
        dataGridView1.Columns["HireDate"].Visible = false;
        dataGridView1.Columns["PostalCode"].Visible = false;
        dataGridView1.Columns["Photo"].Visible = false;
        dataGridView1.Columns["Notes"].Visible = false;
        dataGridView1.Columns["ReportsTo"].Visible = false;
        dataGridView1.Columns["PhotoPath"].Visible = false;

        // Disable sorting for the DataGridView.
        foreach (DataGridViewColumn i in
            dataGridView1.Columns)
        {
            i.SortMode = DataGridViewColumnSortMode.NotSortable;
        }

        dataGridView1.AutoResizeColumns();
    }