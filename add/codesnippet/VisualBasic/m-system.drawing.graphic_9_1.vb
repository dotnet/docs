    Private Sub IntersectClipRegion(ByVal e As PaintEventArgs)

        ' Set clipping region.
        Dim clipRect As New Rectangle(0, 0, 200, 200)
        Dim clipRegion As New [Region](clipRect)
        e.Graphics.SetClip(clipRegion, CombineMode.Replace)

        ' Update clipping region to intersection of

        ' existing region with specified rectangle.
        Dim intersectRect As New Rectangle(100, 100, 200, 200)
        Dim intersectRegion As New [Region](intersectRect)
        e.Graphics.IntersectClip(intersectRegion)

        ' Fill rectangle to demonstrate effective clipping region.
        e.Graphics.FillRectangle(New SolidBrush(Color.Blue), 0, 0, _
        500, 500)

        ' Reset clipping region to infinite.
        e.Graphics.ResetClip()

        ' Draw clipRect and intersectRect to screen.
        e.Graphics.DrawRectangle(New Pen(Color.Black), clipRect)
        e.Graphics.DrawRectangle(New Pen(Color.Red), intersectRect)
    End Sub