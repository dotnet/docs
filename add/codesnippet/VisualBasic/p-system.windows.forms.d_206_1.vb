    ' Style and number columns.
    Private Sub Button8_Click(ByVal sender As Object, _
        ByVal args As EventArgs) Handles Button8.Click

        Dim style As DataGridViewCellStyle = _
            New DataGridViewCellStyle()
        style.Alignment = _
            DataGridViewContentAlignment.MiddleCenter
        style.ForeColor = Color.IndianRed
        style.BackColor = Color.Ivory

        For Each column As DataGridViewColumn _
            In dataGridView.Columns

            column.HeaderCell.Value = _
                column.Index.ToString
            column.HeaderCell.Style = style
        Next
    End Sub