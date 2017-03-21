        // Set a cell padding to provide space for the top of the focus 
        // rectangle and for the content that spans multiple columns. 
        Padding newPadding = new Padding(0, 1, 0, CUSTOM_CONTENT_HEIGHT);
        this.dataGridView1.RowTemplate.DefaultCellStyle.Padding = newPadding;

        // Set the selection background color to transparent so 
        // the cell won't paint over the custom selection background.
        this.dataGridView1.RowTemplate.DefaultCellStyle.SelectionBackColor =
            Color.Transparent;

        // Set the row height to accommodate the content that 
        // spans multiple columns.
        this.dataGridView1.RowTemplate.Height += CUSTOM_CONTENT_HEIGHT;