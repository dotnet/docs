    Public Sub ScaleTransformExample(ByVal e As PaintEventArgs)

        ' Create a graphics path and add a rectangle.
        Dim myPath As New GraphicsPath
        Dim rect As New Rectangle(100, 20, 100, 50)
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

        ' Scale by a factor of 2 in the x-axis by applying the scale
        ' transform to the brush.
        myPGBrush.ScaleTransform(2, 1, MatrixOrder.Append)

        ' Move the brush down by 100 by Applying the translate
        ' transform to the brush.
        myPGBrush.TranslateTransform(-100, 100, MatrixOrder.Append)

        ' Draw the brush to the screen again after applying the
        ' transforms.
        e.Graphics.FillRectangle(myPGBrush, 10, 10, 300, 300)
    End Sub