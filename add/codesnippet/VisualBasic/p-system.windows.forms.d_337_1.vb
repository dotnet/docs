        ' Determine whether the cell should be painted with the 
        ' custom selection background.
        If (e.State And DataGridViewElementStates.Selected) = _
            DataGridViewElementStates.Selected Then

            ' Calculate the bounds of the row.
            Dim rowBounds As New Rectangle( _
                Me.dataGridView1.RowHeadersWidth, e.RowBounds.Top, _
                Me.dataGridView1.Columns.GetColumnsWidth( _
                DataGridViewElementStates.Visible) - _
                Me.dataGridView1.HorizontalScrollingOffset + 1, _
                e.RowBounds.Height)

            ' Paint the custom selection background.
            Dim backbrush As New _
                System.Drawing.Drawing2D.LinearGradientBrush(rowBounds, _
                Me.dataGridView1.DefaultCellStyle.SelectionBackColor, _
                e.InheritedRowStyle.ForeColor, _
                System.Drawing.Drawing2D.LinearGradientMode.Horizontal)
            Try
                e.Graphics.FillRectangle(backbrush, rowBounds)
            Finally
                backbrush.Dispose()
            End Try
        End If