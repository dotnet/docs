        ' Set a cell padding to provide space for the top of the focus 
        ' rectangle and for the content that spans multiple columns. 
        Dim newPadding As New Padding(0, 1, 0, CUSTOM_CONTENT_HEIGHT)
        Me.dataGridView1.RowTemplate.DefaultCellStyle.Padding = newPadding

        ' Set the selection background color to transparent so 
        ' the cell won't paint over the custom selection background.
        Me.dataGridView1.RowTemplate.DefaultCellStyle.SelectionBackColor = _
            Color.Transparent

        ' Set the row height to accommodate the normal cell content and the 
        ' content that spans multiple columns.
        Me.dataGridView1.RowTemplate.Height += CUSTOM_CONTENT_HEIGHT