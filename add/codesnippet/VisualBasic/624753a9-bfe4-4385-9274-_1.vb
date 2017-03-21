    ' Workaround for bug that prevents DataGridViewRowCollection.InsertRange
    ' from working when any rows before the insertion index are selected.
    Private Sub InsertRows(ByVal index As Integer, _
        ByVal ParamArray rows As DataGridViewRow())

        Dim selectedIndexes As New System.Collections.Generic.List(Of Integer)

        For Each row As DataGridViewRow In dataGridView1.SelectedRows
            If row.Index >= index Then
                selectedIndexes.Add(row.Index)
                row.Selected = False
            End If
        Next row

        dataGridView1.Rows.InsertRange(index, rows)

        For Each selectedIndex As Integer In selectedIndexes
            dataGridView1.Rows(selectedIndex).Selected = True
        Next selectedIndex

    End Sub