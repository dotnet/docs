    private void CreateUnboundButtonColumn()
    {
        // Initialize the button column.
        DataGridViewButtonColumn buttonColumn =
            new DataGridViewButtonColumn();
        buttonColumn.Name = "Details";
        buttonColumn.HeaderText = "Details";
        buttonColumn.Text = "View Details";

        // Use the Text property for the button text for all cells rather
        // than using each cell's value as the text for its own button.
        buttonColumn.UseColumnTextForButtonValue = true;

        // Add the button column to the control.
        dataGridView1.Columns.Insert(0, buttonColumn);
    }