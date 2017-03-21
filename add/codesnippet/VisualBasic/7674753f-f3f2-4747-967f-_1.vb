      ' This method draws a border around the button's image. If the background
      ' to be rendered belongs to the empty cell, a string is drawn. Otherwise,
      ' a border is drawn at the edges of the button.
      Protected Overrides Sub OnRenderButtonBackground(e As ToolStripItemRenderEventArgs)
         MyBase.OnRenderButtonBackground(e)
         
         ' Define some local variables for convenience.
         Dim g As Graphics = e.Graphics
         Dim gs As GridStrip = e.ToolStrip 
         Dim gsb As ToolStripButton = e.Item 
         
         ' Calculate the rectangle around which the border is painted.
         Dim imageRectangle As New Rectangle(borderThickness, borderThickness, e.Item.Width - 2 * borderThickness, e.Item.Height - 2 * borderThickness)
         
         ' If rendering the empty cell background, draw an 
         ' explanatory string, centered in the ToolStripButton.
            If gsb Is gs.EmptyCell Then
                e.Graphics.DrawString("Drag to here", gsb.Font, SystemBrushes.ControlDarkDark, imageRectangle, style)
            Else
                ' If the button can be a drag source, paint its border red.
                ' otherwise, paint its border a dark color.
                Dim b As Brush = IIf(gs.IsValidDragSource(gsb), Brushes.Red, SystemBrushes.ControlDarkDark)

                ' Draw the top segment of the border.
                Dim borderSegment As New Rectangle(0, 0, e.Item.Width, imageRectangle.Top)
                g.FillRectangle(b, borderSegment)

                ' Draw the right segment.
                borderSegment = New Rectangle(imageRectangle.Right, 0, e.Item.Bounds.Right - imageRectangle.Right, imageRectangle.Bottom)
                g.FillRectangle(b, borderSegment)

                ' Draw the left segment.
                borderSegment = New Rectangle(0, 0, imageRectangle.Left, e.Item.Height)
                g.FillRectangle(b, borderSegment)

                ' Draw the bottom segment.
                borderSegment = New Rectangle(0, imageRectangle.Bottom, e.Item.Width, e.Item.Bounds.Bottom - imageRectangle.Bottom)
                g.FillRectangle(b, borderSegment)
            End If
        End Sub
    End Class