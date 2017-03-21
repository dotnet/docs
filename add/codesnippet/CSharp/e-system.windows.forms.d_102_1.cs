    private void dataGridView1_RowEnter(object sender, 
        DataGridViewCellEventArgs e)
    {
        for (int i = 0; i < dataGridView1.Rows[e.RowIndex].Cells.Count; i++)
        {
            dataGridView1[i, e.RowIndex].Style.BackColor = Color.Yellow;
        }
    }

    private void dataGridView1_RowLeave(object sender, 
        DataGridViewCellEventArgs e)
    {
        for (int i = 0; i < dataGridView1.Rows[e.RowIndex].Cells.Count; i++)
        {
            dataGridView1[i, e.RowIndex].Style.BackColor = Color.Empty;
        }
    }