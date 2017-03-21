    Private Sub SetClipRegionCombine(ByVal e As PaintEventArgs)

        ' Create region for clipping.
        Dim clipRegion As New [Region](New Rectangle(0, 0, 100, 100))

        ' Set clipping region of graphics to region.
        e.Graphics.SetClip(clipRegion, CombineMode.Replace)

        ' Fill rectangle to demonstrate clip region.
        e.Graphics.FillRectangle(New SolidBrush(Color.Black), 0, 0, _
        500, 300)
    End Sub