   ' This utility method computes the layout of the 
   ' RolloverItem control's image area and the text area.
   ' For brevity, only the following settings are 
   ' supported:
   '
   ' ToolStripTextDirection.Horizontal
   ' TextImageRelation.ImageBeforeText 
   ' TextImageRelation.ImageBeforeText
   ' 
   ' It would not be difficult to support vertical text
   ' directions and other image/text relationships.
   Private Sub ComputeImageAndTextLayout()
      Dim cr As Rectangle = MyBase.ContentRectangle
      Dim img As Image = MyBase.Owner.ImageList.Images(MyBase.ImageKey)
      
      ' Compute the center of the item's ContentRectangle.
        Dim centerY As Integer = CInt((cr.Height - img.Height) / 2)
      
      ' Find the dimensions of the image and the text 
      ' areas of the item. The text occupies the space 
      ' not filled by the image. 
        If MyBase.TextImageRelation = _
        TextImageRelation.ImageBeforeText AndAlso _
        MyBase.TextDirection = ToolStripTextDirection.Horizontal Then

            imageRect = New Rectangle( _
            MyBase.ContentRectangle.Left, _
            centerY, _
            MyBase.Image.Width, _
            MyBase.Image.Height)

            textRect = New Rectangle( _
            imageRect.Width, _
            MyBase.ContentRectangle.Top, _
            MyBase.ContentRectangle.Width - imageRect.Width, _
            MyBase.ContentRectangle.Height)

        ElseIf MyBase.TextImageRelation = _
        TextImageRelation.TextBeforeImage AndAlso _
        MyBase.TextDirection = ToolStripTextDirection.Horizontal Then

            imageRect = New Rectangle( _
            MyBase.ContentRectangle.Right - MyBase.Image.Width, _
            centerY, _
            MyBase.Image.Width, _
            MyBase.Image.Height)

            textRect = New Rectangle( _
            MyBase.ContentRectangle.Left, _
            MyBase.ContentRectangle.Top, _
            imageRect.X, _
            MyBase.ContentRectangle.Bottom)

        End If
    End Sub
End Class