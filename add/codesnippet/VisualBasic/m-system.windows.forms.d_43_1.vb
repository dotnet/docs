    Private clickedCell As DataGridViewCell

    Private Sub dataGridView1_MouseDown(ByVal sender As Object, _
        ByVal e As MouseEventArgs) Handles dataGridView1.MouseDown

        ' If the user right-clicks a cell, store it for use by the 
        ' shortcut menu.
        If e.Button = MouseButtons.Right Then
            Dim hit As DataGridView.HitTestInfo = _
                dataGridView1.HitTest(e.X, e.Y)
            If hit.Type = DataGridViewHitTestType.Cell Then
                clickedCell = _
                    dataGridView1.Rows(hit.RowIndex).Cells(hit.ColumnIndex)
            End If
        End If

    End Sub