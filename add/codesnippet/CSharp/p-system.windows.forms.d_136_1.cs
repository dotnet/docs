    private void Stretch(object sender, EventArgs e)
    {
        foreach (DataGridViewImageColumn column in
            dataGridView1.Columns)
        {
            column.ImageLayout = DataGridViewImageCellLayout.Stretch;
            column.Description = "Stretched";
        }
    }

    private void ZoomToImage(object sender, EventArgs e)
    {

        foreach (DataGridViewImageColumn column in
            dataGridView1.Columns)
        {
            column.ImageLayout = DataGridViewImageCellLayout.Zoom;
            column.Description = "Zoomed";
        }
    }

    private void NormalImage(object sender, EventArgs e)
    {

        foreach (DataGridViewImageColumn column in
            dataGridView1.Columns)
        {
            column.ImageLayout = DataGridViewImageCellLayout.Normal;
            column.Description = "Normal";
        }
    }