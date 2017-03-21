    private void DataGridView1_CellValueChanged(
        object sender, DataGridViewCellEventArgs e)
    {
        // Update the balance column whenever the value of any cell changes.
        UpdateBalance();
    }

    private void DataGridView1_RowsRemoved(
        object sender, DataGridViewRowsRemovedEventArgs e)
    {
        // Update the balance column whenever rows are deleted.
        UpdateBalance();
    }

    private void UpdateBalance()
    {
        int counter;
        int balance;
        int deposit;
        int withdrawal;

        // Iterate through the rows, skipping the Starting Balance row.
        for (counter = 1; counter < (DataGridView1.Rows.Count - 1);
            counter++)
        {
            deposit = 0;
            withdrawal = 0;
            balance = int.Parse(DataGridView1.Rows[counter - 1]
                .Cells["Balance"].Value.ToString());

            if (DataGridView1.Rows[counter].Cells["Deposits"].Value != null)
            {
                // Verify that the cell value is not an empty string.
                if (DataGridView1.Rows[counter]
                    .Cells["Deposits"].Value.ToString().Length != 0)
                {
                    deposit = int.Parse(DataGridView1.Rows[counter]
                        .Cells["Deposits"].Value.ToString());
                }
            }

            if (DataGridView1.Rows[counter].Cells["Withdrawals"].Value != null)
            {
                if (DataGridView1.Rows[counter]
                    .Cells["Withdrawals"].Value.ToString().Length != 0)
                {
                    withdrawal = int.Parse(DataGridView1.Rows[counter]
                        .Cells["Withdrawals"].Value.ToString());
                }
            }
            DataGridView1.Rows[counter].Cells["Balance"].Value =
                (balance + deposit + withdrawal).ToString();
        }
    }