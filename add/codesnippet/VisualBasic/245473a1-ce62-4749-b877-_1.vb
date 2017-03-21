    Public Sub TranslateTransformExample(ByVal e As PaintEventArgs)

        ' Create a LinearGradientBrush.
        Dim myRect As New Rectangle(20, 20, 200, 100)
        Dim myLGBrush As New LinearGradientBrush(myRect, Color.Blue, _
        Color.Red, 0.0F, True)

        ' Draw a rectangle to the screen using the LinearGradientBrush.
        e.Graphics.FillRectangle(myLGBrush, myRect)

        ' Rotate the LinearGradientBrush.
        myLGBrush.RotateTransform(90.0F)

        ' Scale the gradient for the height of the rectangle.
        myLGBrush.ScaleTransform(0.5F, 1.0F)

        ' Draw to the screen, the rotated and scaled gradient.
        e.Graphics.FillRectangle(myLGBrush, 20, 150, 200, 100)

        ' Rejustify the brush to start at the top edge of the rectangle.
        myLGBrush.TranslateTransform(-20.0F, 0.0F)

        ' Draw a third rectangle to the screen using the translated brush.
        e.Graphics.FillRectangle(myLGBrush, 20, 300, 200, 100)
    End Sub