    private void SetUpDataGridView()
    {
        this.Controls.Add(dataGridView1);
        dataGridView1.ColumnCount = 5;
        DataGridViewCellStyle style = 
            dataGridView1.ColumnHeadersDefaultCellStyle;
        style.BackColor = Color.Navy;
        style.ForeColor = Color.White;
        style.Font = new Font(dataGridView1.Font, FontStyle.Bold);

        dataGridView1.EditMode = DataGridViewEditMode.EditOnEnter;
        dataGridView1.Name = "dataGridView1";
        dataGridView1.Location = new Point(8, 8);
        dataGridView1.Size = new Size(500, 300);
        dataGridView1.AutoSizeRowsMode = 
            DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
        dataGridView1.ColumnHeadersBorderStyle = 
            DataGridViewHeaderBorderStyle.Raised;
        dataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.Single;
        dataGridView1.GridColor = SystemColors.ActiveBorder;
        dataGridView1.RowHeadersVisible = false;

        dataGridView1.Columns[0].Name = "Release Date";
        dataGridView1.Columns[1].Name = "Track";
        dataGridView1.Columns[1].DefaultCellStyle.Alignment = 
            DataGridViewContentAlignment.MiddleCenter;
        dataGridView1.Columns[2].Name = "Title";
        dataGridView1.Columns[3].Name = "Artist";
        dataGridView1.Columns[4].Name = "Album";

        // Make the font italic for row four.
        dataGridView1.Columns[4].DefaultCellStyle.Font = new Font(DataGridView.DefaultFont, FontStyle.Italic);

        dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        dataGridView1.MultiSelect = false;

        dataGridView1.BackgroundColor = Color.Honeydew;

        dataGridView1.Dock = DockStyle.Fill;

        dataGridView1.CellFormatting += new DataGridViewCellFormattingEventHandler(dataGridView1_CellFormatting);
        dataGridView1.CellParsing += new DataGridViewCellParsingEventHandler(dataGridView1_CellParsing);
        addNewRowButton.Click += new EventHandler(addNewRowButton_Click);
        deleteRowButton.Click += new EventHandler(deleteRowButton_Click);
        ledgerStyleButton.Click += new EventHandler(ledgerStyleButton_Click);
        dataGridView1.CellValidating += new DataGridViewCellValidatingEventHandler(dataGridView1_CellValidating);

    }