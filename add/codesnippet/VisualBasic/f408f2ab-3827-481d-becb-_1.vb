    Public Sub ScaleTransform_Example2(ByVal e As PaintEventArgs)

        ' Create a Pen object.
        Dim scalePen As New Pen(Color.Black, 5)

        ' Draw a rectangle with scalePen.
        e.Graphics.DrawRectangle(scalePen, 10, 10, 100, 100)

        ' Scale scalePen by 2X in the x-direction.
        scalePen.ScaleTransform(2, 1, MatrixOrder.Prepend)

        ' Draw a second rectangle with rotatePen.
        e.Graphics.DrawRectangle(scalePen, 120, 10, 100, 100)
    End Sub