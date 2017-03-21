    private void SetBorderAndGridlineStyles()
    {
        this.dataGridView1.GridColor = Color.BlueViolet;
        this.dataGridView1.BorderStyle = BorderStyle.Fixed3D;
        this.dataGridView1.CellBorderStyle =
            DataGridViewCellBorderStyle.None;
        this.dataGridView1.RowHeadersBorderStyle =
            DataGridViewHeaderBorderStyle.Single;
        this.dataGridView1.ColumnHeadersBorderStyle =
            DataGridViewHeaderBorderStyle.Single;
    }