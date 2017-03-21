    ' Draws the backgrounds for entire ListView items.
    Private Sub listView1_DrawItem(ByVal sender As Object, _
        ByVal e As DrawListViewItemEventArgs) _
        Handles listView1.DrawItem

        If Not (e.State And ListViewItemStates.Selected) = 0 Then

            ' Draw the background for a selected item.
            e.Graphics.FillRectangle(Brushes.Maroon, e.Bounds)
            e.DrawFocusRectangle()

        Else

            ' Draw the background for an unselected item.
            Dim brush As New LinearGradientBrush(e.Bounds, Color.Orange, _
                Color.Maroon, LinearGradientMode.Horizontal)
            Try
                e.Graphics.FillRectangle(brush, e.Bounds)
            Finally
                brush.Dispose()
            End Try

        End If

        ' Draw the item text for views other than the Details view.
        If Not Me.listView1.View = View.Details Then
            e.DrawText()
        End If

    End Sub