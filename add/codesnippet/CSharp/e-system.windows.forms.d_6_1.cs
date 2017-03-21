    void dataGridView1_RowContextMenuStripNeeded(object sender,
        DataGridViewRowContextMenuStripNeededEventArgs e)
    {
        DataGridViewRow dataGridViewRow1 = dataGridView1.Rows[e.RowIndex];

        toolStripMenuItem1.Enabled = true;

        // Show the appropriate ContextMenuStrip based on the employees title.
        if ((dataGridViewRow1.Cells["Title"].Value.ToString() ==
            "Sales Manager") ||
            (dataGridViewRow1.Cells["Title"].Value.ToString() ==
            "Vice President, Sales"))
        {
            e.ContextMenuStrip = managerMenuStrip;
        }
        else
        {
            e.ContextMenuStrip = employeeMenuStrip;
        }

        contextMenuRowIndex = e.RowIndex;
    }