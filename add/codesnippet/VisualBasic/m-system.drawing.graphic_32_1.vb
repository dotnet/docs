    Private Sub IntersectClipRectangle(ByVal e As PaintEventArgs)

        ' Set clipping region.
        Dim clipRect As New Rectangle(0, 0, 200, 200)
        e.Graphics.SetClip(clipRect)

        ' Update clipping region to intersection of

        ' existing region with specified rectangle.
        Dim intersectRect As New Rectangle(100, 100, 200, 200)
        e.Graphics.IntersectClip(intersectRect)

        ' Fill rectangle to demonstrate effective clipping region.
        e.Graphics.FillRectangle(New SolidBrush(Color.Blue), 0, 0, _
        500, 500)

        ' Reset clipping region to infinite.
        e.Graphics.ResetClip()

        ' Draw clipRect and intersectRect to screen.
        e.Graphics.DrawRectangle(New Pen(Color.Black), clipRect)
        e.Graphics.DrawRectangle(New Pen(Color.Red), intersectRect)
    End Sub