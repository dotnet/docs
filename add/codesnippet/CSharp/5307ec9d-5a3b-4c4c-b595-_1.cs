    private ToolStripMenuItem wholeTable = new ToolStripMenuItem();
    private ToolStripMenuItem lookUp = new ToolStripMenuItem();
    private ContextMenuStrip strip;
    private string cellErrorText;

    private void dataGridView1_CellContextMenuStripNeeded(object sender,
        DataGridViewCellContextMenuStripNeededEventArgs e)
    {
        cellErrorText = String.Empty;

        if (strip == null)
        {
            strip = new ContextMenuStrip();
            lookUp.Text = "Look Up";
            wholeTable.Text = "See Whole Table";
            strip.Items.Add(lookUp);
            strip.Items.Add(wholeTable);
        }
        e.ContextMenuStrip = strip;
    }

    private void wholeTable_Click(object sender, EventArgs e)
    {
        dataGridView1.DataSource = Populate("Select * from employees", true);
    }

    private DataGridViewCellEventArgs theCellImHoveringOver;

    private void dataGridView1_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
    {
        theCellImHoveringOver = e;
    }

    private DataGridViewCellEventArgs cellErrorLocation;

    private void lookUp_Click(object sender, EventArgs e)
    {
        try
        {
            dataGridView1.DataSource = Populate("Select * from employees where " +
                dataGridView1.Columns[theCellImHoveringOver.ColumnIndex].Name + " = '" +
                dataGridView1.Rows[theCellImHoveringOver.RowIndex].
                Cells[theCellImHoveringOver.ColumnIndex].Value + "'",
                true);
        }
        catch (SqlException)
        {
            cellErrorText = "Can't look this cell up";
            cellErrorLocation = theCellImHoveringOver;
        }
    }

    private void dataGridView1_CellErrorTextNeeded(object sender,
        DataGridViewCellErrorTextNeededEventArgs e)
    {
        if (cellErrorLocation != null)
        {
            if (e.ColumnIndex == cellErrorLocation.ColumnIndex &&
                e.RowIndex == cellErrorLocation.RowIndex)
            {
                e.ErrorText = cellErrorText;
            }
        }
    }

    private DataTable Populate(string query, bool resetUnsharedCounter)
    {
        if (resetUnsharedCounter)
        {
            ResetCounter();
        }

        // Alter the data source as necessary
        SqlDataAdapter adapter = new SqlDataAdapter(query,
            new SqlConnection("Integrated Security=SSPI;Persist Security Info=False;" +
            "Initial Catalog=Northwind;Data Source=localhost"));

        DataTable table = new DataTable();
        table.Locale = System.Globalization.CultureInfo.InvariantCulture;
        adapter.Fill(table);
        return table;
    }

    private Label count = new Label();
    private int unsharedRowCounter;

    private void ResetCounter()
    {
        unsharedRowCounter = 0;
        count.Text = unsharedRowCounter.ToString();
    }