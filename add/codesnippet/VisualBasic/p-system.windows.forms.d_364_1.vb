    WithEvents toolStripItem1 As New ToolStripMenuItem()

    Private Sub AddContextMenu()
        toolStripItem1.Text = "Redden"
        Dim strip As New ContextMenuStrip()
        For Each column As DataGridViewColumn _
            In dataGridView.Columns()

            column.ContextMenuStrip = strip
            column.ContextMenuStrip.Items.Add(toolStripItem1)
        Next
    End Sub
    ' Change the cell's color.
    Private Sub toolStripItem1_Click(ByVal sender As Object, _
        ByVal args As EventArgs) _
        Handles toolStripItem1.Click

        dataGridView.Rows(mouseLocation.RowIndex) _
            .Cells(mouseLocation.ColumnIndex) _
            .Style.BackColor = Color.Red
    End Sub

    Private mouseLocation As DataGridViewCellEventArgs

    ' Deal with hovering over a cell.
    Private Sub dataGridView_CellMouseEnter(ByVal sender As Object, _
        ByVal location As DataGridViewCellEventArgs) _
        Handles DataGridView.CellMouseEnter

        mouseLocation = location
    End Sub