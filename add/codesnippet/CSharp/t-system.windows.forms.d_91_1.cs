    private void dataGridView1_DefaultValuesNeeded(object sender,
        System.Windows.Forms.DataGridViewRowEventArgs e)
    {
        e.Row.Cells["Region"].Value = "WA";
        e.Row.Cells["City"].Value = "Redmond";
        e.Row.Cells["PostalCode"].Value = "98052-6399";
        e.Row.Cells["Country"].Value = "USA";
        e.Row.Cells["CustomerID"].Value = NewCustomerId();
    }