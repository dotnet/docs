   ' This class implements a custom ToolStripRenderer for the 
   ' GridStrip control. It customizes three aspects of the 
   ' GridStrip control's appearance: GridStrip border, 
   ' ToolStripButton border, and ToolStripButton image.
   Friend Class GridStripRenderer
        Inherits ToolStripRenderer

      ' The style of the empty cell's text.
      Private Shared style As New StringFormat()
      
      ' The thickness (width or height) of a 
      ' ToolStripButton control's border.
      Private Shared borderThickness As Integer = 2
      
      ' The main bitmap that is the source for the 
      ' subimagesthat are assigned to individual 
      ' ToolStripButton controls.
      Private bmp As Bitmap = Nothing
      
      ' The brush that paints the background of 
      ' the GridStrip control.
      Private backgroundBrush As Brush = Nothing
      
      
      ' This is the static constructor. It initializes the
      ' StringFormat for drawing the text in the empty cell.
      Shared Sub New()
         style.Alignment = StringAlignment.Center
         style.LineAlignment = StringAlignment.Center
      End Sub 
      
      ' This method initializes the GridStripRenderer by
      ' creating the image that is used as the source for
      ' the individual button images.
      Protected Overrides Sub Initialize(ts As ToolStrip)
         MyBase.Initialize(ts)
         
         Me.InitializeBitmap(ts)
        End Sub

      ' This method initializes an individual ToolStripButton
      ' control. It copies a subimage from the GridStripRenderer's
      ' main image, according to the position and size of 
      ' the ToolStripButton.
      Protected Overrides Sub InitializeItem(item As ToolStripItem)
         MyBase.InitializeItem(item)
         
            Dim gs As GridStrip = item.Owner
         
         ' The empty cell does not receive a subimage.
            If ((TypeOf (item) Is ToolStripButton) And _
                 (item IsNot gs.EmptyCell)) Then
                ' Copy the subimage from the appropriate 
                ' part of the main image.
                Dim subImage As Bitmap = bmp.Clone(item.Bounds, PixelFormat.Undefined)

                ' Assign the subimage to the ToolStripButton
                ' control's Image property.
                item.Image = subImage
            End If
      End Sub 

      ' This utility method creates the main image that
      ' is the source for the subimages of the individual 
      ' ToolStripButton controls.
      Private Sub InitializeBitmap(toolStrip As ToolStrip)
         ' Create the main bitmap, into which the image is drawn.
         Me.bmp = New Bitmap(toolStrip.Size.Width, toolStrip.Size.Height)
         
         ' Draw a fancy pattern. This could be any image or drawing.
         Dim g As Graphics = Graphics.FromImage(bmp)
         Try
            ' Draw smoothed lines.
            g.SmoothingMode = SmoothingMode.AntiAlias
            
            ' Draw the image. In this case, it is 
            ' a number of concentric ellipses. 
            Dim i As Integer
            For i = 0 To toolStrip.Size.Width - 8 Step 8
               g.DrawEllipse(Pens.Blue, 0, 0, i, i)
            Next i
         Finally
            g.Dispose()
         End Try
      End Sub 
      
      ' This method draws a border around the GridStrip control.
      Protected Overrides Sub OnRenderToolStripBorder(e As ToolStripRenderEventArgs)
         MyBase.OnRenderToolStripBorder(e)
         
         ControlPaint.DrawFocusRectangle(e.Graphics, e.AffectedBounds, SystemColors.ControlDarkDark, SystemColors.ControlDarkDark)
      End Sub 

      ' This method renders the GridStrip control's background.
      Protected Overrides Sub OnRenderToolStripBackground(e As ToolStripRenderEventArgs)
         MyBase.OnRenderToolStripBackground(e)
         
         ' This late initialization is a workaround. The gradient
         ' depends on the bounds of the GridStrip control. The bounds 
         ' are dependent on the layout engine, which hasn't fully
         ' performed layout by the time the Initialize method runs.
         If Me.backgroundBrush Is Nothing Then
            Me.backgroundBrush = New LinearGradientBrush(e.ToolStrip.ClientRectangle, SystemColors.ControlLightLight, SystemColors.ControlDark, 90, True)
         End If
         
         ' Paint the GridStrip control's background.
         e.Graphics.FillRectangle(Me.backgroundBrush, e.AffectedBounds)
        End Sub

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