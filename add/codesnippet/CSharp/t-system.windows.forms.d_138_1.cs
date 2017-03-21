    private void Form1_Load(object sender, System.EventArgs e)
    {
        // Bind the DataGridView controls to the BindingSource
        // components and load the data from the database.
        masterDataGridView.DataSource = masterBindingSource;
        detailsDataGridView.DataSource = detailsBindingSource;
        GetData();

        // Resize the master DataGridView columns to fit the newly loaded data.
        masterDataGridView.AutoResizeColumns();

        // Configure the details DataGridView so that its columns automatically
        // adjust their widths when the data changes.
        detailsDataGridView.AutoSizeColumnsMode = 
            DataGridViewAutoSizeColumnsMode.AllCells;
    }