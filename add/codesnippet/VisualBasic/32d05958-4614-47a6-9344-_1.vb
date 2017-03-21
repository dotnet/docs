    ' Paints the content that spans multiple columns and the focus rectangle.
    Sub dataGridView1_RowPostPaint(ByVal sender As Object, _
        ByVal e As DataGridViewRowPostPaintEventArgs) _
        Handles dataGridView1.RowPostPaint

        ' Calculate the bounds of the row.
        Dim rowBounds As New Rectangle(Me.dataGridView1.RowHeadersWidth, _
            e.RowBounds.Top, Me.dataGridView1.Columns.GetColumnsWidth( _
            DataGridViewElementStates.Visible) - _
            Me.dataGridView1.HorizontalScrollingOffset + 1, e.RowBounds.Height)

        Dim forebrush As SolidBrush = Nothing
        Try
            ' Determine the foreground color.
            If (e.State And DataGridViewElementStates.Selected) = _
                DataGridViewElementStates.Selected Then

                forebrush = New SolidBrush(e.InheritedRowStyle.SelectionForeColor)
            Else
                forebrush = New SolidBrush(e.InheritedRowStyle.ForeColor)
            End If

            ' Get the content that spans multiple columns.
            Dim recipe As Object = _
                Me.dataGridView1.Rows.SharedRow(e.RowIndex).Cells(2).Value

            If (recipe IsNot Nothing) Then
                Dim text As String = recipe.ToString()

                ' Calculate the bounds for the content that spans multiple 
                ' columns, adjusting for the horizontal scrolling position 
                ' and the current row height, and displaying only whole
                ' lines of text.
                Dim textArea As Rectangle = rowBounds
                textArea.X -= Me.dataGridView1.HorizontalScrollingOffset
                textArea.Width += Me.dataGridView1.HorizontalScrollingOffset
                textArea.Y += rowBounds.Height - e.InheritedRowStyle.Padding.Bottom
                textArea.Height -= rowBounds.Height - e.InheritedRowStyle.Padding.Bottom
                textArea.Height = (textArea.Height \ e.InheritedRowStyle.Font.Height) * _
                    e.InheritedRowStyle.Font.Height

                ' Calculate the portion of the text area that needs painting.
                Dim clip As RectangleF = textArea
                clip.Width -= Me.dataGridView1.RowHeadersWidth + 1 - clip.X
                clip.X = Me.dataGridView1.RowHeadersWidth + 1
                Dim oldClip As RectangleF = e.Graphics.ClipBounds
                e.Graphics.SetClip(clip)

                ' Draw the content that spans multiple columns.
                e.Graphics.DrawString(text, e.InheritedRowStyle.Font, forebrush, _
                    textArea)

                e.Graphics.SetClip(oldClip)
            End If
        Finally
            forebrush.Dispose()
        End Try

        If Me.dataGridView1.CurrentCellAddress.Y = e.RowIndex Then
            ' Paint the focus rectangle.
            e.DrawFocus(rowBounds, True)
        End If

    End Sub 'dataGridView1_RowPostPaint