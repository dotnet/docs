    Private Sub TranslateTransformAngleMatrixOrder(ByVal e As PaintEventArgs)

        ' Set world transform of graphics object to rotate.
        e.Graphics.RotateTransform(30.0F)

        ' Then to translate, appending to world transform.
        e.Graphics.TranslateTransform(100.0F, 0.0F, MatrixOrder.Append)

        ' Draw rotated, translated ellipse to screen.
        e.Graphics.DrawEllipse(New Pen(Color.Blue, 3), 0, 0, 200, 80)
    End Sub