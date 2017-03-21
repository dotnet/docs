    private void ValidateByRow(Object sender, 
        DataGridViewCellCancelEventArgs data) 
    {
        DataGridViewRow row = 
            songsDataGridView.Rows[data.RowIndex];
        DataGridViewCell trackCell = 
            row.Cells[songsDataGridView.Columns["Track"].Index];
        DataGridViewCell dateCell = 
            row.Cells[songsDataGridView.Columns["Release Date"].Index];
        data.Cancel = !(IsTrackGood(trackCell) && IsDateGood(dateCell));
    }

    private Boolean IsTrackGood(DataGridViewCell cell)
    {
        Int32 cellValueAsInt;
        if (cell.Value.ToString().Length == 0)
		{
            cell.ErrorText = "Please enter a track";
            songsDataGridView.Rows[cell.RowIndex].ErrorText = 
                "Please enter a track";
            return false;
        }
        else if (cell.Value.ToString().Equals("0"))
        {
            cell.ErrorText = "Zero is not a valid track";
            songsDataGridView.Rows[cell.RowIndex].ErrorText =
                "Zero is not a valid track";
            return false;
        }
        else if (!Int32.TryParse(cell.Value.ToString(), out cellValueAsInt))
        {
            cell.ErrorText = "A Track must be a number";
            songsDataGridView.Rows[cell.RowIndex].ErrorText =
                "A Track must be a number";
            return false;
        }
        return true;
    }

    private Boolean IsDateGood(DataGridViewCell cell) 
    {
        if (cell.Value == null)
		{
            cell.ErrorText = "Missing date";
            songsDataGridView.Rows[cell.RowIndex].ErrorText = 
                "Missing date";
            return false;
        }
        else
        {
            try
            {
                DateTime.Parse(cell.Value.ToString());
            }
            catch (FormatException)
            {
                cell.ErrorText = "Invalid format";
                songsDataGridView.Rows[cell.RowIndex].ErrorText = 
                    "Invalid format";

                return false;
            }
        }
        return true;
    }