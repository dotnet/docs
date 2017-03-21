    Private Sub SortButton_Click(ByVal sender As Object, _
        ByVal e As EventArgs) Handles sortButton.Click

        ' Check which column is selected, otherwise set NewColumn to Nothing.
        Dim newColumn As DataGridViewColumn
        If dataGridView1.Columns.GetColumnCount(DataGridViewElementStates _
            .Selected) = 1 Then
            newColumn = dataGridView1.SelectedColumns(0)
        Else
            newColumn = Nothing
        End If

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


        ' If no column has been selected, display an error dialog  box.
        If newColumn Is Nothing Then
            MessageBox.Show("Select a single column and try again.", _
                "Error: Invalid Selection", MessageBoxButtons.OK, _
                MessageBoxIcon.Error)
        Else
            dataGridView1.Sort(newColumn, direction)
            If direction = ListSortDirection.Ascending Then
                newColumn.HeaderCell.SortGlyphDirection = SortOrder.Ascending
            Else
                newColumn.HeaderCell.SortGlyphDirection = SortOrder.Descending
            End If
        End If

    End Sub