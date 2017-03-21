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