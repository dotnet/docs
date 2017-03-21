    // Freeze the first row.
    private void Button4_Click(object sender, System.EventArgs e)
    {

        FreezeBand(dataGridView.Rows[0]);
    }

    private void Button5_Click(object sender, System.EventArgs e)
    {

        FreezeBand(dataGridView.Columns[1]);
    }

    private static void FreezeBand(DataGridViewBand band)
    {
        band.Frozen = true;
        DataGridViewCellStyle style = new DataGridViewCellStyle();
        style.BackColor = Color.WhiteSmoke;
        band.DefaultCellStyle = style;
    }