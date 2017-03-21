    ' Forces the row to repaint itself when the user changes the 
    ' current cell. This is necessary to refresh the focus rectangle.
    Sub dataGridView1_CurrentCellChanged(ByVal sender As Object, _
        ByVal e As EventArgs) Handles dataGridView1.CurrentCellChanged

        If oldRowIndex <> -1 Then
            Me.dataGridView1.InvalidateRow(oldRowIndex)
        End If
        oldRowIndex = Me.dataGridView1.CurrentCellAddress.Y

    End Sub 'dataGridView1_CurrentCellChanged