    Public Sub MultiplyTransformExample(ByVal e As PaintEventArgs)

        ' Create a graphics path and add a rectangle.
        Dim myPath As New GraphicsPath
        Dim rect As New Rectangle(20, 20, 100, 50)
        myPath.AddRectangle(rect)

        ' Get the path's array of points.
        Dim myPathPointArray As PointF() = myPath.PathPoints

        ' Create a path gradient brush.
        Dim myPGBrush As New PathGradientBrush(myPathPointArray)

        ' Set the color span.
        myPGBrush.CenterColor = Color.Red
        Dim mySurroundColor As Color() = {Color.Blue}
        myPGBrush.SurroundColors = mySurroundColor

        ' Draw the brush to the screen prior to transformation.
        e.Graphics.FillRectangle(myPGBrush, 10, 10, 200, 200)

        ' Create a new matrix that rotates by 90 degrees, and
        ' translates by 100 in each direction.
        Dim myMatrix As New Matrix(0, 1, -1, 0, 100, 100)

        ' Apply the transform to the brush.
        myPGBrush.MultiplyTransform(myMatrix, MatrixOrder.Append)

        ' Draw the brush to the screen again after applying the
        ' transform.
        e.Graphics.FillRectangle(myPGBrush, 10, 10, 200, 300)
    End Sub