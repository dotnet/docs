    private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
    {

        if (IsANonHeaderLinkCell(e))
        {
            MoveToLinked(e);
        }
        else if (IsANonHeaderButtonCell(e))
        {
            PopulateSales(e);
        }
    }

    private void MoveToLinked(DataGridViewCellEventArgs e)
    {
        string employeeId;
        object value = DataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
        if (value is DBNull) { return; }

        employeeId = value.ToString();
        DataGridViewCell boss = RetrieveSuperiorsLastNameCell(employeeId);
        if (boss != null)
        {
            DataGridView1.CurrentCell = boss;
        }
    }

    private bool IsANonHeaderLinkCell(DataGridViewCellEventArgs cellEvent)
    {
        if (DataGridView1.Columns[cellEvent.ColumnIndex] is
            DataGridViewLinkColumn &&
            cellEvent.RowIndex != -1)
        { return true; }
        else { return false; }
    }

    private bool IsANonHeaderButtonCell(DataGridViewCellEventArgs cellEvent)
    {
        if (DataGridView1.Columns[cellEvent.ColumnIndex] is
            DataGridViewButtonColumn &&
            cellEvent.RowIndex != -1)
        { return true; }
        else { return (false); }
    }

    private DataGridViewCell RetrieveSuperiorsLastNameCell(string employeeId)
    {

        foreach (DataGridViewRow row in DataGridView1.Rows)
        {
            if (row.IsNewRow) { return null; }
            if (row.Cells[ColumnName.EmployeeId.ToString()].Value.ToString().Equals(employeeId))
            {
                return row.Cells[ColumnName.LastName.ToString()];
            }
        }
        return null;
    }