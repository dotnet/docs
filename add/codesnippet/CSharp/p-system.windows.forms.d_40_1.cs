    private void dataGridView1_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
    {

        DataGridViewColumn column = dataGridView1.Columns[e.ColumnIndex];

        if (column.Name == "Track")
        {
            CheckTrack(e);
        }
        else if (column.Name == "Release Date")
        {
            CheckDate(e);
        }
    }

    private static void CheckTrack(DataGridViewCellValidatingEventArgs newValue)
    {
        Int32 ignored = new Int32();
        if (String.IsNullOrEmpty(newValue.FormattedValue.ToString()))
        {
            NotifyUserAndForceRedo("Please enter a track", newValue);
        }
        else if (!Int32.TryParse(newValue.FormattedValue.ToString(), out ignored))
        {
            NotifyUserAndForceRedo("A Track must be a number", newValue);
        }
        else if (Int32.Parse(newValue.FormattedValue.ToString()) < 1)
        {
            NotifyUserAndForceRedo("Not a valid track", newValue);
        }
    }

    private static void NotifyUserAndForceRedo(string errorMessage, DataGridViewCellValidatingEventArgs newValue)
    {
        MessageBox.Show(errorMessage);
        newValue.Cancel = true;
    }

    private void CheckDate(DataGridViewCellValidatingEventArgs newValue)
    {
        try
        {
            DateTime.Parse(newValue.FormattedValue.ToString()).ToLongDateString();
            AnnotateCell(String.Empty, newValue);
        }
        catch (FormatException)
        {
            AnnotateCell("You did not enter a valid date.", newValue);
        }
    }

    private void AnnotateCell(string errorMessage, DataGridViewCellValidatingEventArgs editEvent)
    {

        DataGridViewCell cell = dataGridView1.Rows[editEvent.RowIndex].Cells[editEvent.ColumnIndex];
        cell.ErrorText = errorMessage;
    }