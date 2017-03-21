    private void RemoveAnnotations(Object sender, 
        DataGridViewCellEventArgs args) 
    {
        foreach (DataGridViewCell cell in 
            songsDataGridView.Rows[args.RowIndex].Cells)
        {
            cell.ErrorText = String.Empty;
        }

        foreach (DataGridViewRow row in songsDataGridView.Rows)
        {
            row.ErrorText = String.Empty;
        }
    }