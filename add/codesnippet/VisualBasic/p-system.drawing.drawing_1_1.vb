    Private Sub DemonstrateBlend(ByVal e As PaintEventArgs)
        Dim blend1 As New Blend(9)

        ' Set the values in the Factors array to be all green, 
        ' go to all blue, and then go back to green.
        blend1.Factors = New Single() {0.0F, 0.2F, 0.5F, 0.7F, 1.0F, _
            0.7F, 0.5F, 0.2F, 0.0F}

        ' Set the positions.
        blend1.Positions = New Single() {0.0F, 0.1F, 0.3F, 0.4F, 0.5F, _
            0.6F, 0.7F, 0.8F, 1.0F}

        ' Declare a rectangle to draw the Blend in.
        Dim rectangle1 As New Rectangle(10, 10, 120, 100)

        ' Create a new LinearGradientBrush using the rectangle, 
        ' green and blue. and 90-degree angle.
        Dim brush1 As New LinearGradientBrush(rectangle1, _
            Color.LightGreen, Color.Blue, 90, True)

        ' Set the Blend property on the brush to the custom blend.
        brush1.Blend = blend1

        ' Fill in an ellipse with the brush.
        e.Graphics.FillEllipse(brush1, rectangle1)

        ' Dispose of the custom brush.
        brush1.Dispose()
    End Sub