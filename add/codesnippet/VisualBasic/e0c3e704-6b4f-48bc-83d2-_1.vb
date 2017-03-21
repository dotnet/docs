    Public Sub ScaleTransformExample(ByVal e As PaintEventArgs)

        ' Create a LinearGradientBrush.
        Dim myRect As New Rectangle(20, 20, 200, 100)
        Dim myLGBrush As New LinearGradientBrush(myRect, Color.Blue, _
        Color.Red, 0.0F, True)

        ' Draw an ellipse to the screen using the LinearGradientBrush.
        e.Graphics.FillEllipse(myLGBrush, myRect)

        ' Scale the LinearGradientBrush.
        myLGBrush.ScaleTransform(2.0F, 1.0F, MatrixOrder.Prepend)

        ' Rejustify the brush to start at the left edge of the ellipse.
        myLGBrush.TranslateTransform(-20.0F, 0.0F)

        ' Draw a second ellipse to the screen using the transformed brush.
        e.Graphics.FillEllipse(myLGBrush, 20, 150, 200, 100)
    End Sub