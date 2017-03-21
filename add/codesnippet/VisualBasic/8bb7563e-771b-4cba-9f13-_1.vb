    Private Sub SetClipGraphicsCombine(ByVal e As PaintEventArgs)

        ' Create temporary graphics object and set its clipping region.
        Dim newGraphics As Graphics = Me.CreateGraphics()
        newGraphics.SetClip(New Rectangle(0, 0, 100, 100))

        ' Update clipping region of graphics to clipping region of new

        ' graphics.
        e.Graphics.SetClip(newGraphics, CombineMode.Replace)

        ' Fill rectangle to demonstrate clip region.
        e.Graphics.FillRectangle(New SolidBrush(Color.Black), 0, 0, _
        500, 300)

        ' Release new graphics.
        newGraphics.Dispose()
    End Sub