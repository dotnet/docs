    Private Sub IntersectClipRectangleF2(ByVal e As PaintEventArgs)

        ' Set clipping region.
        Dim clipRect As New Rectangle(0, 0, 200, 200)
        e.Graphics.SetClip(clipRect)

        ' Update clipping region to intersection of

        ' existing region with specified rectangle.
        Dim intersectRectF As New RectangleF(100.0F, 100.0F, 200.0F, 200.0F)
        e.Graphics.IntersectClip(intersectRectF)

        ' Fill rectangle to demonstrate effective clipping region.
        e.Graphics.FillRectangle(New SolidBrush(Color.Blue), 0, 0, _
        500, 500)

        ' Reset clipping region to infinite.
        e.Graphics.ResetClip()

        ' Draw clipRect and intersectRect to screen.
        e.Graphics.DrawRectangle(New Pen(Color.Black), clipRect)
        e.Graphics.DrawRectangle(New Pen(Color.Red), _
        Rectangle.Round(intersectRectF))
    End Sub