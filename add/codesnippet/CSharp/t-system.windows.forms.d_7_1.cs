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

    private void dataGridView1_CellToolTipTextNeeded(object sender,
        DataGridViewCellToolTipTextNeededEventArgs e)
    {

        if (theCellImHoveringOver.ColumnIndex == dataGridView1.Columns["ReportsTo"].Index &&
            theCellImHoveringOver.RowIndex > -1)
        {

            string reportsTo = dataGridView1.Rows[theCellImHoveringOver.RowIndex].
                Cells[theCellImHoveringOver.ColumnIndex].Value.ToString();

            if (String.IsNullOrEmpty(reportsTo))
            {
                e.ToolTipText = "The buck stops here!";
            }
            else
            {
                DataTable table = Populate(
                    "select firstname, lastname from employees where employeeid = '" +
                    dataGridView1.Rows[theCellImHoveringOver.RowIndex].
                    Cells[theCellImHoveringOver.ColumnIndex].Value.ToString() +
                    "'", false);

                e.ToolTipText = "Reports to " + table.Rows[0].ItemArray[0] + " " +
                    table.Rows[0].ItemArray[1];
            }
        }
    }