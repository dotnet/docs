    ' This method defines the behavior for rendering the
    ' background of a ToolStripItem. If the item is a
    ' RolloverItem, it paints the item's BackgroundImage 
    ' centered in the client area. If the mouse is in the 
    ' item's client area, a border is drawn around it.
    ' If the item is on a drop-down or if it is on the
    ' overflow, a gradient is painted in the background.
    Protected Overrides Sub OnRenderItemBackground(ByVal e As ToolStripItemRenderEventArgs)
        MyBase.OnRenderItemBackground(e)

        Dim item As RolloverItem = CType(e.Item, RolloverItem)

        ' If the ToolSTripItem is of type RolloverItem, 
        ' perform custom rendering for the background.
        If (item IsNot Nothing) Then
            If item.Placement = ToolStripItemPlacement.Overflow OrElse item.IsOnDropDown Then
                Dim b As New LinearGradientBrush(item.ContentRectangle, Color.Salmon, Color.DarkRed, 0.0F, False)
                Try
                    e.Graphics.FillRectangle(b, item.ContentRectangle)
                Finally
                    b.Dispose()
                End Try
            End If

            ' The RolloverItem control only supports 
            ' the ImageLayout.Center setting for the
            ' BackgroundImage property.
            If item.BackgroundImageLayout = ImageLayout.Center Then
                ' Get references to the item's ContentRectangle
                ' and BackgroundImage, for convenience.
                Dim cr As Rectangle = item.ContentRectangle
                Dim bgi As Image = item.BackgroundImage

                ' Compute the center of the item's ContentRectangle.
                Dim centerX As Integer = CInt((cr.Width - bgi.Width) / 2)
                Dim centerY As Integer = CInt((cr.Height - bgi.Height) / 2)

                ' If the item is selected, draw the background
                ' image as usual. Otherwise, draw it as disabled.
                If item.Selected Then
                    e.Graphics.DrawImage(bgi, centerX, centerY)
                Else
                    ControlPaint.DrawImageDisabled(e.Graphics, bgi, centerX, centerY, item.BackColor)
                End If
            End If

            ' If the item is in the rollover state, 
            ' draw a border around it.
            If item.Rollover Then
                ControlPaint.DrawFocusRectangle(e.Graphics, item.ContentRectangle)
            End If
        End If
    End Sub