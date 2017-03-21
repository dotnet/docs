    Public Sub ExcludeClipRegion(ByVal e As PaintEventArgs)

        ' Create rectangle for region.
        Dim excludeRect As New Rectangle(100, 100, 200, 200)

        ' Create region for exclusion.
        Dim excludeRegion As New [Region](excludeRect)

        ' Set clipping region to exclude region.
        e.Graphics.ExcludeClip(excludeRegion)

        ' Fill large rectangle to show clipping region.
        e.Graphics.FillRectangle(New SolidBrush(Color.Blue), 0, 0, _
        300, 300)
    End Sub