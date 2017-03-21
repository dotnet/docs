    Private Sub dataGridView1_CellClick(ByVal sender As Object, _
        ByVal e As DataGridViewCellEventArgs) _
        Handles dataGridView1.CellClick

        If turn.Text.Equals(gameOverString) Then Return

        Dim cell As DataGridViewImageCell = _
            CType(dataGridView1.Rows(e.RowIndex). _
                Cells(e.ColumnIndex), DataGridViewImageCell)
        If (cell.Value Is blank) Then
            If IsOsTurn() Then
                cell.Value = o
            Else
                cell.Value = x
            End If
            ToggleTurn()
            ToolTip(e)
        End If
        If IsAWin() Then
            turn.Text = gameOverString
        End If
    End Sub