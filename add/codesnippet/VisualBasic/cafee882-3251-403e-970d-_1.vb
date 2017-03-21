    Private Sub ScaleTransformFloatMatrixOrder(ByVal e As PaintEventArgs)

        ' Set world transform of graphics object to rotate.
        e.Graphics.RotateTransform(30.0F)

        ' Then to scale, appending to world transform.
        e.Graphics.ScaleTransform(3.0F, 1.0F, MatrixOrder.Append)

        ' Draw rotated, scaled rectangle to screen.
        e.Graphics.DrawRectangle(New Pen(Color.Blue, 3), 50, 0, 100, 40)
    End Sub