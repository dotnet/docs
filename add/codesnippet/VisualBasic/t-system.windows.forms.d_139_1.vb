    Private Sub dataGridView1_CellMouseEnter(ByVal sender As Object, _
        ByVal e As DataGridViewCellEventArgs) _
        Handles dataGridView1.CellMouseEnter

        Dim markingUnderMouse As Bitmap = _
            CType(dataGridView1.Rows(e.RowIndex). _
                Cells(e.ColumnIndex).Value, Bitmap)

        If markingUnderMouse Is blank Then
            dataGridView1.Cursor = Cursors.Default
        ElseIf markingUnderMouse Is o OrElse markingUnderMouse Is x Then
            dataGridView1.Cursor = Cursors.No
            ToolTip(e)
        End If
    End Sub

    Private Sub ToolTip( _
        ByVal e As DataGridViewCellEventArgs)

        Dim cell As DataGridViewImageCell = _
            CType(dataGridView1.Rows(e.RowIndex). _
            Cells(e.ColumnIndex), DataGridViewImageCell)
        Dim imageColumn As DataGridViewImageColumn = _
            CType(dataGridView1.Columns(cell.ColumnIndex), _
            DataGridViewImageColumn)

        cell.ToolTipText = imageColumn.Description
    End Sub

    Private Sub dataGridView1_CellMouseLeave(ByVal sender As Object, _
        ByVal e As DataGridViewCellEventArgs) _
        Handles dataGridView1.CellMouseLeave

        dataGridView1.Cursor = Cursors.Default
    End Sub