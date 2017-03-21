    // Configures the appearance and behavior of a DataGridView control.
    private void InitializeDataGridView()
    {
        // Initialize basic DataGridView properties.
        dataGridView1.Dock = DockStyle.Fill;
        dataGridView1.BackgroundColor = Color.LightGray;
        dataGridView1.BorderStyle = BorderStyle.Fixed3D;

        // Set property values appropriate for read-only display and 
        // limited interactivity. 
        dataGridView1.AllowUserToAddRows = false;
        dataGridView1.AllowUserToDeleteRows = false;
        dataGridView1.AllowUserToOrderColumns = true;
        dataGridView1.ReadOnly = true;
        dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        dataGridView1.MultiSelect = false;
        dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
        dataGridView1.AllowUserToResizeColumns = false;
        dataGridView1.ColumnHeadersHeightSizeMode = 
            DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
        dataGridView1.AllowUserToResizeRows = false;
        dataGridView1.RowHeadersWidthSizeMode = 
            DataGridViewRowHeadersWidthSizeMode.DisableResizing;

        // Set the selection background color for all the cells.
        dataGridView1.DefaultCellStyle.SelectionBackColor = Color.White;
        dataGridView1.DefaultCellStyle.SelectionForeColor = Color.Black;

        // Set RowHeadersDefaultCellStyle.SelectionBackColor so that its default
        // value won't override DataGridView.DefaultCellStyle.SelectionBackColor.
        dataGridView1.RowHeadersDefaultCellStyle.SelectionBackColor = Color.Empty;

        // Set the background color for all rows and for alternating rows. 
        // The value for alternating rows overrides the value for all rows. 
        dataGridView1.RowsDefaultCellStyle.BackColor = Color.LightGray;
        dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.DarkGray;

        // Set the row and column header styles.
        dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
        dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.Black;
        dataGridView1.RowHeadersDefaultCellStyle.BackColor = Color.Black;

        // Set the Format property on the "Last Prepared" column to cause
        // the DateTime to be formatted as "Month, Year".
        dataGridView1.Columns["Last Prepared"].DefaultCellStyle.Format = "y";

        // Specify a larger font for the "Ratings" column. 
        using (Font font = new Font(
            dataGridView1.DefaultCellStyle.Font.FontFamily, 25, FontStyle.Bold))
        {
            dataGridView1.Columns["Rating"].DefaultCellStyle.Font = font;
        }

        // Attach a handler to the CellFormatting event.
        dataGridView1.CellFormatting += new
            DataGridViewCellFormattingEventHandler(dataGridView1_CellFormatting);
    }