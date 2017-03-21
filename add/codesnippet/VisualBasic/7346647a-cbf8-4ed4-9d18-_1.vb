    Private Sub TransformPointsPoint(ByVal e As PaintEventArgs)

        ' Create array of two points.
        Dim points As Point() = {New Point(0, 0), New Point(100, 50)}

        ' Draw line connecting two untransformed points.
        e.Graphics.DrawLine(New Pen(Color.Blue, 3), points(0), points(1))

        ' Set world transformation of Graphics object to translate.
        e.Graphics.TranslateTransform(40, 30)

        ' Transform points in array from world to page coordinates.
        e.Graphics.TransformPoints(CoordinateSpace.Page, _
        CoordinateSpace.World, points)

        ' Reset world transformation.
        e.Graphics.ResetTransform()

        ' Draw line that connects transformed points.
        e.Graphics.DrawLine(New Pen(Color.Red, 3), points(0), points(1))
    End Sub