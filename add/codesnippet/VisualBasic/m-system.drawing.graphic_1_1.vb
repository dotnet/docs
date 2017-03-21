    Private Sub SetClipRectangleF(ByVal e As PaintEventArgs)

        ' Create rectangle for clipping region.
        Dim clipRect As New RectangleF(0.0F, 0.0F, 100.0F, 100.0F)

        ' Set clipping region of graphics to rectangle.
        e.Graphics.SetClip(clipRect)

        ' Fill rectangle to demonstrate clip region.
        e.Graphics.FillRectangle(New SolidBrush(Color.Black), 0, 0, _
        500, 300)
    End Sub