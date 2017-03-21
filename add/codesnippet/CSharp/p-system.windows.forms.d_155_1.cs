    private void ChangeColumnAlignment()
    {
        songsDataGridView.Columns["Title"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter;
        songsDataGridView.Columns["Title"].Name = DataGridViewContentAlignment.BottomCenter.ToString();

        songsDataGridView.Columns["Artist"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft;
        songsDataGridView.Columns["Artist"].Name = DataGridViewContentAlignment.BottomLeft.ToString();

        songsDataGridView.Columns["Album"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight;
        songsDataGridView.Columns["Album"].Name = DataGridViewContentAlignment.BottomRight.ToString();

        songsDataGridView.Columns["Release Date"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        songsDataGridView.Columns["Release Date"].Name = DataGridViewContentAlignment.MiddleCenter.ToString();

        songsDataGridView.Columns["Track"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
        songsDataGridView.Columns["Track"].Name = DataGridViewContentAlignment.MiddleLeft.ToString();
    }