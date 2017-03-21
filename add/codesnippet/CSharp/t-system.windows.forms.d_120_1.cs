    bool newRowNeeded;
    private void dataGridView1_NewRowNeeded(object sender,
        DataGridViewRowEventArgs e)
    {
        newRowNeeded = true;
    }

    const int initialSize = 5000000;
    int numberOfRows = initialSize;

    private void dataGridView1_RowsAdded(object sender,
         DataGridViewRowsAddedEventArgs e)
    {
        if (newRowNeeded)
        {
            newRowNeeded = false;
            numberOfRows = numberOfRows + 1;
        }
    }

    #region "data store maintance"
    const int initialValue = -1;

    private void dataGridView1_CellValueNeeded(object sender,
        DataGridViewCellValueEventArgs e)
    {
        if (store.ContainsKey(e.RowIndex))
        {
            // Use the store if the e value has been modified 
            // and stored.            
            e.Value = store[e.RowIndex];
        }
        else if (newRowNeeded && e.RowIndex == numberOfRows)
        {
            if (dataGridView1.IsCurrentCellInEditMode)
            {
                e.Value = initialValue;
            }
            else
            {
                // Show a blank value if the cursor is just resting
                // on the last row.
                e.Value = String.Empty;
            }
        }
        else
        {
            e.Value = e.RowIndex;
        }
    }

    private void dataGridView1_CellValuePushed(object sender,
        DataGridViewCellValueEventArgs e)
    {
        store.Add(e.RowIndex, int.Parse(e.Value.ToString()));
    }
    #endregion

    private Dictionary<int, int> store = new Dictionary<int, int>();