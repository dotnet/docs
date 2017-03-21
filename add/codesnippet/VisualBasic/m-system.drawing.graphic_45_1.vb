    Private Sub TranslateClipFloat(ByVal e As PaintEventArgs)

        ' Create rectangle for clipping region.
        Dim clipRect As New RectangleF(0.0F, 0.0F, 100.0F, 100.0F)

        ' Set clipping region of graphics to rectangle.
        e.Graphics.SetClip(clipRect)

        ' Translate clipping region.
        Dim dx As Single = 50.0F
        Dim dy As Single = 50.0F
        e.Graphics.TranslateClip(dx, dy)

        ' Fill rectangle to demonstrate translated clip region.
        e.Graphics.FillRectangle(New SolidBrush(Color.Black), 0, 0, _
        500, 300)
    End Sub