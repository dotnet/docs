    Public Sub SetBlendTriangularShapeExample(ByVal e As PaintEventArgs)

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

        ' Draw the brush to the screen prior to blend.
        e.Graphics.FillRectangle(myPGBrush, 10, 10, 200, 200)

        ' Set the Blend factors.
        myPGBrush.SetBlendTriangularShape(0.5F, 1.0F)

        ' Move the brush down by 100 by Applying the translate
        ' transform to the brush.
        myPGBrush.TranslateTransform(0, 100, MatrixOrder.Append)

        ' Draw the brush to the screen again after applying the
        ' transforms.
        e.Graphics.FillRectangle(myPGBrush, 10, 10, 300, 300)
    End Sub