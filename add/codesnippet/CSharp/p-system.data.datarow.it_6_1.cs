    private void DataGrid1_Click(object sender, 
        System.EventArgs e) 
    {
        DataTable dataGridTable = 
            (DataTable)DataGrid1.DataSource;

        // Set the current row using the RowNumber 
        // property of the CurrentCell.
        DataRow currentRow = dataGridTable.Rows[DataGrid1.CurrentCell.RowNumber];
        DataColumn column = dataGridTable.Columns[1];

        // Get the value of the column 1 in the DataTable.
        Console.WriteLine(currentRow[column, DataRowVersion.Current]);
    }