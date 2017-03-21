    ' This event handler manually raises the CellValueChanged event
    ' by calling the CommitEdit method.
    Sub dataGridView1_CurrentCellDirtyStateChanged( _
        ByVal sender As Object, ByVal e As EventArgs) _
        Handles dataGridView1.CurrentCellDirtyStateChanged

        If dataGridView1.IsCurrentCellDirty Then
            dataGridView1.CommitEdit(DataGridViewDataErrorContexts.Commit)
        End If
    End Sub

    ' If a check box cell is clicked, this event handler disables  
    ' or enables the button in the same row as the clicked cell.
    Public Sub dataGridView1_CellValueChanged(ByVal sender As Object, _
        ByVal e As DataGridViewCellEventArgs) _
        Handles dataGridView1.CellValueChanged

        If dataGridView1.Columns(e.ColumnIndex).Name = "CheckBoxes" Then
            Dim buttonCell As DataGridViewDisableButtonCell = _
                CType(dataGridView1.Rows(e.RowIndex).Cells("Buttons"), _
                DataGridViewDisableButtonCell)

            Dim checkCell As DataGridViewCheckBoxCell = _
                CType(dataGridView1.Rows(e.RowIndex).Cells("CheckBoxes"), _
                DataGridViewCheckBoxCell)
            buttonCell.Enabled = Not CType(checkCell.Value, [Boolean])

            dataGridView1.Invalidate()
        End If
    End Sub