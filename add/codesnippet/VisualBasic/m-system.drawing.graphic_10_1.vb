    Private Sub MultiplyTransformMatrix(ByVal e As PaintEventArgs)

        ' Create transform matrix.
        Dim transformMatrix As New Matrix

        ' Translate matrix, prepending translation vector.
        transformMatrix.Translate(200.0F, 100.0F)

        ' Rotate transformation matrix of graphics object,

        ' prepending rotation matrix.
        e.Graphics.RotateTransform(30.0F)

        ' Multiply (prepend to) transformation matrix of

        ' graphics object to translate graphics transformation.
        e.Graphics.MultiplyTransform(transformMatrix)

        ' Draw rotated, translated ellipse.
        e.Graphics.DrawEllipse(New Pen(Color.Blue, 3), -80, -40, 160, 80)
    End Sub