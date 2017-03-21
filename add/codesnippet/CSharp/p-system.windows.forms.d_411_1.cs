    private void SetupDataGridView()
    {
        this.Controls.Add(songsDataGridView);

        songsDataGridView.ColumnCount = 5;

        songsDataGridView.ColumnHeadersDefaultCellStyle.BackColor = Color.Navy;
        songsDataGridView.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
        songsDataGridView.ColumnHeadersDefaultCellStyle.Font =
            new Font(songsDataGridView.Font, FontStyle.Bold);

        songsDataGridView.Name = "songsDataGridView";
        songsDataGridView.Location = new Point(8, 8);
        songsDataGridView.Size = new Size(500, 250);
        songsDataGridView.AutoSizeRowsMode =
            DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
        songsDataGridView.ColumnHeadersBorderStyle =
            DataGridViewHeaderBorderStyle.Single;
        songsDataGridView.CellBorderStyle = DataGridViewCellBorderStyle.Single;
        songsDataGridView.GridColor = Color.Black;
        songsDataGridView.RowHeadersVisible = false;

        songsDataGridView.Columns[0].Name = "Release Date";
        songsDataGridView.Columns[1].Name = "Track";
        songsDataGridView.Columns[2].Name = "Title";
        songsDataGridView.Columns[3].Name = "Artist";
        songsDataGridView.Columns[4].Name = "Album";
        songsDataGridView.Columns[4].DefaultCellStyle.Font =
            new Font(songsDataGridView.DefaultCellStyle.Font, FontStyle.Italic);

        songsDataGridView.SelectionMode =
            DataGridViewSelectionMode.FullRowSelect;
        songsDataGridView.MultiSelect = false;
        songsDataGridView.Dock = DockStyle.Fill;

        songsDataGridView.CellFormatting += new
            DataGridViewCellFormattingEventHandler(
            songsDataGridView_CellFormatting);
    }