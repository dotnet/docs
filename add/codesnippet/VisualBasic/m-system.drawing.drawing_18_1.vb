    Public Sub CloneExample(ByVal e As PaintEventArgs)

        ' Create a LinearGradientBrush.
        Dim x As Integer = 20
        Dim y As Integer = 20
        Dim h As Integer = 100
        Dim w As Integer = 200
        Dim myRect As New Rectangle(x, y, w, h)
        Dim myLGBrush As New LinearGradientBrush(myRect, Color.Blue, _
        Color.Aquamarine, 45.0F, True)

        ' Draw an ellipse to the screen using the LinearGradientBrush.
        e.Graphics.FillEllipse(myLGBrush, x, y, w, h)

        ' Clone the LinearGradientBrush.
        Dim clonedLGBrush As LinearGradientBrush = _
        CType(myLGBrush.Clone(), LinearGradientBrush)

        ' Justify the left edge of the gradient with the left edge of the
        ' ellipse.
        clonedLGBrush.TranslateTransform(-100.0F, 0.0F)

        ' Draw a second ellipse to the screen using the cloned HBrush.
        y = 150
        e.Graphics.FillEllipse(clonedLGBrush, x, y, w, h)
    End Sub