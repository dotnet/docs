    Public Sub SetSigmaBellShapeExample(ByVal e As PaintEventArgs)

        ' Create a LinearGradientBrush.
        Dim myRect As New Rectangle(20, 20, 200, 100)
        Dim myLGBrush As New LinearGradientBrush(myRect, Color.Blue, _
        Color.Red, 0.0F, True)

        ' Draw an ellipse to the screen using the LinearGradientBrush.
        e.Graphics.FillEllipse(myLGBrush, myRect)

        ' Create a triangular shaped brush with the peak at the center
        ' of the drawing area.
        myLGBrush.SetSigmaBellShape(0.5F, 1.0F)

        ' Use the triangular brush to draw a second ellipse.
        myRect.Y = 150
        e.Graphics.FillEllipse(myLGBrush, myRect)
    End Sub