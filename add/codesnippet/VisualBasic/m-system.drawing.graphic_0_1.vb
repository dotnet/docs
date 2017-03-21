    Public Sub ExcludeClipRectangle(ByVal e As PaintEventArgs)

        ' Create rectangle for exclusion.
        Dim excludeRect As New Rectangle(100, 100, 200, 200)

        ' Set clipping region to exclude rectangle.
        e.Graphics.ExcludeClip(excludeRect)

        ' Fill large rectangle to show clipping region.
        e.Graphics.FillRectangle(New SolidBrush(Color.Blue), 0, 0, _
        300, 300)
    End Sub