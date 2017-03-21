    Public Sub ResetTransformExample(ByVal e As PaintEventArgs)

        ' Create a LinearGradientBrush.
        Dim myRect As New Rectangle(20, 20, 200, 100)
        Dim myLGBrush As New LinearGradientBrush(myRect, Color.Blue, _
        Color.Red, 0.0F, True)

        ' Draw an ellipse to the screen using the LinearGradientBrush.
        e.Graphics.FillEllipse(myLGBrush, myRect)

        ' Transform the LinearGradientBrush.
        Dim transformArray As Point() = {New Point(20, 150), _
        New Point(400, 150), New Point(20, 200)}
        Dim myMatrix As New Matrix(myRect, transformArray)
        myLGBrush.MultiplyTransform(myMatrix, MatrixOrder.Prepend)

        ' Draw a second ellipse to the screen using the transformed brush.
        e.Graphics.FillEllipse(myLGBrush, 20, 150, 380, 50)

        ' Reset the brush transform.
        myLGBrush.ResetTransform()

        ' Draw a third ellipse to the screen using the reset brush.
        e.Graphics.FillEllipse(myLGBrush, 20, 250, 200, 100)
    End Sub