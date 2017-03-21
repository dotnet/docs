    Public Sub RotateTransform_Example1(ByVal e As PaintEventArgs)

        ' Create a Pen object.
        Dim rotatePen As New Pen(Color.Black, 5)

        ' Draw a rectangle with rotatePen.
        e.Graphics.DrawRectangle(rotatePen, 10, 10, 100, 100)

        ' Scale rotatePen by 2X in the x-direction.
        rotatePen.ScaleTransform(2, 1)

        ' Rotate rotatePen 90 degrees clockwise.
        rotatePen.RotateTransform(90)

        ' Draw a second rectangle with rotatePen.
        e.Graphics.DrawRectangle(rotatePen, 140, 10, 100, 100)
    End Sub