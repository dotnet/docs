        ' Create a header for the table.
        Dim header As New TableHeaderCell()
        header.RowSpan = 1
        header.ColumnSpan = 3
        header.Text = "Table of (x,y) Values"
        header.Font.Bold = True
        header.BackColor = Color.Gray
        header.HorizontalAlign = HorizontalAlign.Center
        header.VerticalAlign = VerticalAlign.Middle

        ' Add the header to a new row.
        Dim headerRow As New TableRow()
        headerRow.Cells.Add(header)

        ' Add the header row to the table.
        Table1.Rows.AddAt(0, headerRow)