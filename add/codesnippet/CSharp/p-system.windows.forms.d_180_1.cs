    private void PostRowCreation()
    {
        SetBandColor(dataGridView.Columns[0], Color.CadetBlue);
        SetBandColor(dataGridView.Rows[1], Color.Coral);
        SetBandColor(dataGridView.Columns[2], Color.DodgerBlue);
    }

    private static void SetBandColor(DataGridViewBand band, Color color)
    {
        band.Tag = color;
    }

    // Color the bands by the value stored in their tag.
    private void Button9_Click(object sender, System.EventArgs e)
    {

        foreach (DataGridViewBand band in dataGridView.Columns)
        {
            if (band.Tag != null)
            {
                band.DefaultCellStyle.BackColor = (Color)band.Tag;
            }
        }

        foreach (DataGridViewBand band in dataGridView.Rows)
        {
            if (band.Tag != null)
            {
                band.DefaultCellStyle.BackColor = (Color)band.Tag;
            }
        }
    }