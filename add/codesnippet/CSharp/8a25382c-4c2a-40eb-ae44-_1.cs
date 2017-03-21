    // Adjusts the padding when the user changes the row height so that 
    // the normal cell content is fully displayed and any extra
    // height is used for the content that spans multiple columns.
    void dataGridView1_RowHeightChanged(object sender,
        DataGridViewRowEventArgs e)
    {
        // Calculate the new height of the normal cell content.
        Int32 preferredNormalContentHeight =
            e.Row.GetPreferredHeight(e.Row.Index, 
            DataGridViewAutoSizeRowMode.AllCellsExceptHeader, true) -
            e.Row.DefaultCellStyle.Padding.Bottom;

        // Specify a new padding.
        Padding newPadding = e.Row.DefaultCellStyle.Padding;
        newPadding.Bottom = e.Row.Height - preferredNormalContentHeight;
        e.Row.DefaultCellStyle.Padding = newPadding;
    }