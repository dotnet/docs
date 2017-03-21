    Private Sub dataGridView1_ColumnHeaderMouseClick(ByVal sender As Object, _
        ByVal e As DataGridViewCellMouseEventArgs) _
        Handles dataGridView1.ColumnHeaderMouseClick

        Dim newColumn As DataGridViewColumn = _
            dataGridView1.Columns(e.ColumnIndex)
        Dim oldColumn As DataGridViewColumn = dataGridView1.SortedColumn
        Dim direction As ListSortDirection

        ' If oldColumn is null, then the DataGridView is not currently sorted.
        If oldColumn IsNot Nothing Then

            ' Sort the same column again, reversing the SortOrder.
            If oldColumn Is newColumn AndAlso dataGridView1.SortOrder = _
                SortOrder.Ascending Then
                direction = ListSortDirection.Descending
            Else

                ' Sort a new column and remove the old SortGlyph.
                direction = ListSortDirection.Ascending
                oldColumn.HeaderCell.SortGlyphDirection = SortOrder.None
            End If
        Else
            direction = ListSortDirection.Ascending
        End If

        ' Sort the selected column.
        dataGridView1.Sort(newColumn, direction)
        If direction = ListSortDirection.Ascending Then
            newColumn.HeaderCell.SortGlyphDirection = SortOrder.Ascending
        Else
            newColumn.HeaderCell.SortGlyphDirection = SortOrder.Descending
        End If

    End Sub

    Private Sub dataGridView1_DataBindingComplete(ByVal sender As Object, _
        ByVal e As DataGridViewBindingCompleteEventArgs) _
        Handles dataGridView1.DataBindingComplete

        ' Put each of the columns into programmatic sort mode.
        For Each column As DataGridViewColumn In dataGridView1.Columns
            column.SortMode = DataGridViewColumnSortMode.Programmatic
        Next
    End Sub