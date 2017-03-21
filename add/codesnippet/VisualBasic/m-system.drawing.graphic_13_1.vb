    Private Sub FillRegionRectangle(ByVal e As PaintEventArgs)

        ' Create solid brush.
        Dim blueBrush As New SolidBrush(Color.Blue)

        ' Create rectangle for region.
        Dim fillRect As New Rectangle(100, 100, 200, 200)

        ' Create region for fill.
        Dim fillRegion As New [Region](fillRect)

        ' Fill region to screen.
        e.Graphics.FillRegion(blueBrush, fillRegion)
    End Sub