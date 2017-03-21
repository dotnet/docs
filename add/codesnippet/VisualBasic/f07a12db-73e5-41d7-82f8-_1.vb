    Private Sub SetClipRectangleCombine(ByVal e As PaintEventArgs)

        ' Create rectangle for clipping region.
        Dim clipRect As New Rectangle(0, 0, 100, 100)

        ' Set clipping region of graphics to rectangle.
        e.Graphics.SetClip(clipRect, CombineMode.Replace)

        ' Fill rectangle to demonstrate clip region.
        e.Graphics.FillRectangle(New SolidBrush(Color.Black), 0, 0, _
        500, 300)
    End Sub