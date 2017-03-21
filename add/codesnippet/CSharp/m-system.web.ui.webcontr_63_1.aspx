        // Create a header for the table.
        TableHeaderCell header = new TableHeaderCell();
        header.RowSpan = 1;
        header.ColumnSpan = 3;
        header.Text = "Table of (x,y) Values";
        header.Font.Bold = true;
        header.BackColor = Color.Gray;
        header.HorizontalAlign = HorizontalAlign.Center;
        header.VerticalAlign = VerticalAlign.Middle;

        // Add the header to a new row.
        TableRow headerRow = new TableRow();
        headerRow.Cells.Add(header);

        // Add the header row to the table.
        Table1.Rows.AddAt(0, headerRow);  