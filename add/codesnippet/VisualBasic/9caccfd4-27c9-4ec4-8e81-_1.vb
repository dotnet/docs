    Private Sub TransformPointsPointF(ByVal e As PaintEventArgs)

        ' Create array of two points.
        Dim points As PointF() = {New PointF(0.0F, 0.0F), New PointF(100.0F, _
        50.0F)}

        ' Draw line connecting two untransformed points.
        e.Graphics.DrawLine(New Pen(Color.Blue, 3), points(0), points(1))

        ' Set world transformation of Graphics object to translate.
        e.Graphics.TranslateTransform(40.0F, 30.0F)

        ' Transform points in array from world to page coordinates.
        e.Graphics.TransformPoints(CoordinateSpace.Page, _
        CoordinateSpace.World, points)

        ' Reset world transformation.
        e.Graphics.ResetTransform()

        ' Draw line that connects transformed points.
        e.Graphics.DrawLine(New Pen(Color.Red, 3), points(0), points(1))
    End Sub