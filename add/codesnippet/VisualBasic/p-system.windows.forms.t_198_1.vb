    Protected Overrides Sub OnRenderItemImage(ByVal e As ToolStripItemImageRenderEventArgs)
        MyBase.OnRenderItemImage(e)

        Dim item As RolloverItem = CType(e.Item, RolloverItem)

        ' If the ToolSTripItem is of type RolloverItem, 
        ' perform custom rendering for the image.
        If (item IsNot Nothing) Then
            If item.Clicked Then
                ' The item is in the clicked state, so 
                ' draw the image as usual.
                e.Graphics.DrawImage(e.Image, e.ImageRectangle.X, e.ImageRectangle.Y)
            Else
                ' In the unclicked state, gray out the image.
                ControlPaint.DrawImageDisabled(e.Graphics, e.Image, e.ImageRectangle.X, e.ImageRectangle.Y, item.BackColor)
            End If
        End If
    End Sub