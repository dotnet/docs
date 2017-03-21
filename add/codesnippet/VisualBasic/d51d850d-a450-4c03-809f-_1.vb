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