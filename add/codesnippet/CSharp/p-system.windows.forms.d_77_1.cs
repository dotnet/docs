        public CustomDataGridView()
        {
            this.RowTemplate = new DataGridViewCustomRow();
            this.Columns.Add(new DataGridViewCustomColumn());
            this.Columns.Add(new DataGridViewCustomColumn());
            this.Columns.Add(new DataGridViewCustomColumn());
            this.RowCount = 4;
            this.EnableHeadersVisualStyles = false;
            this.AutoSize = true;
        }