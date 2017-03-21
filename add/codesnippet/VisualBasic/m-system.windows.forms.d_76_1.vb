    Public Function CloneWithValues(ByVal row As DataGridViewRow) _
        As DataGridViewRow

        CloneWithValues = CType(row.Clone(), DataGridViewRow)
        For index As Int32 = 0 To row.Cells.Count - 1
            CloneWithValues.Cells(index).Value = row.Cells(index).Value
        Next

    End Function