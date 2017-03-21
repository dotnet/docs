    Private Sub SetClipPath(ByVal e As PaintEventArgs)

        ' Create graphics path.
        Dim clipPath As New GraphicsPath
        clipPath.AddEllipse(0, 0, 200, 100)

        ' Set clipping region to path.
        e.Graphics.SetClip(clipPath)

        ' Fill rectangle to demonstrate clipping region.
        e.Graphics.FillRectangle(New SolidBrush(Color.Black), 0, 0, _
        500, 300)
    End Sub