    // Make the the entire DataGridView read only.
    private void Button8_Click(object sender, System.EventArgs e)
    {
        foreach (DataGridViewBand band in dataGridView.Columns)
        {
            band.ReadOnly = true;
        }
    }