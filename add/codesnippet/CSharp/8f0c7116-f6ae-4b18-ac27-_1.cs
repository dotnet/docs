    private void selectedColumnsButton_Click(object sender, System.EventArgs e)
    {
        Int32 selectedColumnCount = dataGridView1.Columns
            .GetColumnCount(DataGridViewElementStates.Selected);
        if (selectedColumnCount > 0)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();

            for (int i = 0; i < selectedColumnCount; i++)
            {
                sb.Append("Column: ");
                sb.Append(dataGridView1.SelectedColumns[i].Index
                    .ToString());
                sb.Append(Environment.NewLine);
            }

            sb.Append("Total: " + selectedColumnCount.ToString());
            MessageBox.Show(sb.ToString(), "Selected Columns");
        }
    }