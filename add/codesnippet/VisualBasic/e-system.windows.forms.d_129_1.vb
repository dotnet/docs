    ' Adjusts the padding when the user changes the row height so that 
    ' the normal cell content is fully displayed and any extra
    ' height is used for the content that spans multiple columns.
    Sub dataGridView1_RowHeightChanged(ByVal sender As Object, _
        ByVal e As DataGridViewRowEventArgs) _
        Handles dataGridView1.RowHeightChanged

        ' Calculate the new height of the normal cell content.
        Dim preferredNormalContentHeight As Int32 = _
            e.Row.GetPreferredHeight(e.Row.Index, _
            DataGridViewAutoSizeRowMode.AllCellsExceptHeader, True) - _
            e.Row.DefaultCellStyle.Padding.Bottom()

        ' Specify a new padding.
        Dim newPadding As Padding = e.Row.DefaultCellStyle.Padding
        newPadding.Bottom = e.Row.Height - preferredNormalContentHeight
        e.Row.DefaultCellStyle.Padding = newPadding

    End Sub