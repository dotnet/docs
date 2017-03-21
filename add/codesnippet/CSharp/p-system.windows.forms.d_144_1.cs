    ToolStripMenuItem toolStripItem1 = new ToolStripMenuItem();

    private void AddContextMenu()
    {
        toolStripItem1.Text = "Redden";
        toolStripItem1.Click += new EventHandler(toolStripItem1_Click);
        ContextMenuStrip strip = new ContextMenuStrip();
        foreach (DataGridViewColumn column in dataGridView.Columns)
        {

            column.ContextMenuStrip = strip;
            column.ContextMenuStrip.Items.Add(toolStripItem1);
        }
    }

    private DataGridViewCellEventArgs mouseLocation;

    // Change the cell's color.
    private void toolStripItem1_Click(object sender, EventArgs args)
    {
        dataGridView.Rows[mouseLocation.RowIndex]
            .Cells[mouseLocation.ColumnIndex].Style.BackColor
            = Color.Red;
    }

    // Deal with hovering over a cell.
    private void dataGridView_CellMouseEnter(object sender,
        DataGridViewCellEventArgs location)
    {
        mouseLocation = location;
    }