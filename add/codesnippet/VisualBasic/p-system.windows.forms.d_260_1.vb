    Private Sub CustomizeCellsInThirdColumn()

        Dim thirdColumn As Integer = 2
        Dim column As DataGridViewColumn = _
            dataGridView.Columns(thirdColumn)
        Dim cell As DataGridViewCell = _
            New DataGridViewTextBoxCell()

        cell.Style.BackColor = Color.Wheat
        column.CellTemplate = cell
    End Sub