    Private Sub DataGridView1_SortCompare( _
        ByVal sender As Object, ByVal e As DataGridViewSortCompareEventArgs) _
        Handles DataGridView1.SortCompare

        ' Try to sort based on the contents of the cell in the current column.
        e.SortResult = System.String.Compare(e.CellValue1.ToString(), _
            e.CellValue2.ToString())

        ' If the cells are equal, sort based on the ID column.
        If (e.SortResult = 0) AndAlso Not (e.Column.Name = "ID") Then
            e.SortResult = System.String.Compare( _
                DataGridView1.Rows(e.RowIndex1).Cells("ID").Value.ToString(), _
                DataGridView1.Rows(e.RowIndex2).Cells("ID").Value.ToString())
        End If

        e.Handled = True

    End Sub