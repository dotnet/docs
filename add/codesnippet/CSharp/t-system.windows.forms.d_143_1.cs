    private void dataGridView1_CellClick(object sender,
        DataGridViewCellEventArgs e)
    {

        if (turn.Text.Equals(gameOverString)) { return; }

        DataGridViewImageCell cell = (DataGridViewImageCell)
            dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex];

        if (cell.Value == blank)
        {
            if (IsOsTurn())
            {
                cell.Value = o;
            }
            else
            {
                cell.Value = x;
            }
            ToggleTurn();
        }
        if (IsAWin())
        {
            turn.Text = gameOverString;
        }
    }