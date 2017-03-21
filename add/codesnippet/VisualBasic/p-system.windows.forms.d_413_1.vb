    ' Draws subitem text and applies content-based formatting.
    Private Sub listView1_DrawSubItem(ByVal sender As Object, _
        ByVal e As DrawListViewSubItemEventArgs) _
        Handles listView1.DrawSubItem

        Dim flags As TextFormatFlags = TextFormatFlags.Left

        Dim sf As New StringFormat()
        Try

            ' Store the column text alignment, letting it default
            ' to Left if it has not been set to Center or Right.
            Select Case e.Header.TextAlign
                Case HorizontalAlignment.Center
                    sf.Alignment = StringAlignment.Center
                    flags = TextFormatFlags.HorizontalCenter
                Case HorizontalAlignment.Right
                    sf.Alignment = StringAlignment.Far
                    flags = TextFormatFlags.Right
            End Select

            ' Draw the text and background for a subitem with a 
            ' negative value. 
            Dim subItemValue As Double
            If e.ColumnIndex > 0 AndAlso _
                Double.TryParse(e.SubItem.Text, NumberStyles.Currency, _
                NumberFormatInfo.CurrentInfo, subItemValue) AndAlso _
                subItemValue < 0 Then

                ' Unless the item is selected, draw the standard 
                ' background to make it stand out from the gradient.
                If (e.ItemState And ListViewItemStates.Selected) = 0 Then
                    e.DrawBackground()
                End If

                ' Draw the subitem text in red to highlight it. 
                e.Graphics.DrawString(e.SubItem.Text, _
                    Me.listView1.Font, Brushes.Red, e.Bounds, sf)

                Return

            End If

            ' Draw normal text for a subitem with a nonnegative 
            ' or nonnumerical value.
            e.DrawText(flags)

        Finally
            sf.Dispose()
        End Try

    End Sub