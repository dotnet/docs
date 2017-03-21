    Public Sub dataGridView1_RowContextMenuStripNeeded( _
        ByVal sender As Object, _
        ByVal e As DataGridViewRowContextMenuStripNeededEventArgs) _
        Handles dataGridView1.RowContextMenuStripNeeded

        Dim dataGridViewRow1 As DataGridViewRow = _
        dataGridView1.Rows(e.RowIndex)

        toolStripMenuItem1.Enabled = True

        ' Show the appropriate ContextMenuStrip based on the employees title.
        If dataGridViewRow1.Cells("Title").Value.ToString() = _
            "Sales Manager" OrElse _
            dataGridViewRow1.Cells("Title").Value.ToString() = _
            "Vice President, Sales" Then

            e.ContextMenuStrip = managerMenuStrip
        Else
            e.ContextMenuStrip = employeeMenuStrip
        End If

        contextMenuRowIndex = e.RowIndex
    End Sub