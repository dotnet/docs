    private void UpdateLabelText()
    {
        int WithdrawalTotal = 0;
        int DepositTotal = 0;
        int SelectedCellTotal = 0;
        int counter;

        // Iterate through all the rows and sum up the appropriate columns.
        for (counter = 0; counter < (DataGridView1.Rows.Count);
            counter++)
        {
            if (DataGridView1.Rows[counter].Cells["Withdrawals"].Value
                != null)
            {
                if (DataGridView1.Rows[counter].
                    Cells["Withdrawals"].Value.ToString().Length != 0)
                {
                    WithdrawalTotal += int.Parse(DataGridView1.Rows[counter].
                        Cells["Withdrawals"].Value.ToString());
                }
            }

            if (DataGridView1.Rows[counter].Cells["Deposits"].Value != null)
            {
                if (DataGridView1.Rows[counter]
                    .Cells["Deposits"].Value.ToString().Length != 0)
                {
                    DepositTotal += int.Parse(DataGridView1.Rows[counter]
                        .Cells["Deposits"].Value.ToString());
                }
            }
        }

        // Iterate through the SelectedCells collection and sum up the values.
        for (counter = 0;
            counter < (DataGridView1.SelectedCells.Count); counter++)
        {
            if (DataGridView1.SelectedCells[counter].FormattedValueType ==
                Type.GetType("System.String"))
            {
                string value = null;

                // If the cell contains a value that has not been commited,
                // use the modified value.
                if (DataGridView1.IsCurrentCellDirty == true)
                {

                    value = DataGridView1.SelectedCells[counter]
                        .EditedFormattedValue.ToString();
                }
                else
                {
                    value = DataGridView1.SelectedCells[counter]
                        .FormattedValue.ToString();
                }
                if (value != null)
                {
                    // Ignore cells in the Description column.
                    if (DataGridView1.SelectedCells[counter].ColumnIndex !=
                        DataGridView1.Columns["Description"].Index)
                    {
                        if (value.Length != 0)
                        {
                            SelectedCellTotal += int.Parse(value);
                        }
                    }
                }
            }
        }

        // Set the labels to reflect the current state of the DataGridView.
        Label1.Text = "Withdrawals Total: " + WithdrawalTotal.ToString();
        Label2.Text = "Deposits Total: " + DepositTotal.ToString();
        Label3.Text = "Selected Cells Total: " + SelectedCellTotal.ToString();
        Label4.Text = "Total entries: " + DataGridView1.RowCount.ToString();
    }