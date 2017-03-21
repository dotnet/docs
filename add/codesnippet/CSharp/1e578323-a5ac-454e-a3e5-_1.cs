    private void selectedRowsButton_Click(object sender, System.EventArgs e)
    {
        Int32 selectedRowCount =
            dataGridView1.Rows.GetRowCount(DataGridViewElementStates.Selected);
        if (selectedRowCount > 0)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();

            for (int i = 0; i < selectedRowCount; i++)
            {
                sb.Append("Row: ");
                sb.Append(dataGridView1.SelectedRows[i].Index.ToString());
                sb.Append(Environment.NewLine);
            }

            sb.Append("Total: " + selectedRowCount.ToString());
            MessageBox.Show(sb.ToString(), "Selected Rows");
        }
    }