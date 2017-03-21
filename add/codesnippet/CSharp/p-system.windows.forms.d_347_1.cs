    // This event handler manually raises the CellValueChanged event
    // by calling the CommitEdit method.
    void dataGridView1_CurrentCellDirtyStateChanged(object sender,
        EventArgs e)
    {
        if (dataGridView1.IsCurrentCellDirty)
        {
            dataGridView1.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }
    }

    // If a check box cell is clicked, this event handler disables  
    // or enables the button in the same row as the clicked cell.
    public void dataGridView1_CellValueChanged(object sender,
        DataGridViewCellEventArgs e)
    {
        if (dataGridView1.Columns[e.ColumnIndex].Name == "CheckBoxes")
        {
            DataGridViewDisableButtonCell buttonCell =
                (DataGridViewDisableButtonCell)dataGridView1.
                Rows[e.RowIndex].Cells["Buttons"];

            DataGridViewCheckBoxCell checkCell =
                (DataGridViewCheckBoxCell)dataGridView1.
                Rows[e.RowIndex].Cells["CheckBoxes"];
            buttonCell.Enabled = !(Boolean)checkCell.Value;

            dataGridView1.Invalidate();
        }
    }