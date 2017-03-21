    Private Sub TranslateClipInt(ByVal e As PaintEventArgs)

        ' Create rectangle for clipping region.
        Dim clipRect As New Rectangle(0, 0, 100, 100)

        ' Set clipping region of graphics to rectangle.
        e.Graphics.SetClip(clipRect)

        ' Translate clipping region.
        Dim dx As Integer = 50
        Dim dy As Integer = 50
        e.Graphics.TranslateClip(dx, dy)

        ' Fill rectangle to demonstrate translated clip region.
        e.Graphics.FillRectangle(New SolidBrush(Color.Black), 0, 0, _
        500, 300)
    End Sub