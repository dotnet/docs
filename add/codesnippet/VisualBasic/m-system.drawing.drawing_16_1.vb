    Protected Overrides Sub OnPaint(ByVal e As System.Windows.Forms.PaintEventArgs)
        ' Draw ellipse using ColorBlend.
        Dim startPoint2 As New Point(20, 110)
        Dim endPoint2 As New Point(140, 110)
        Dim myColors As Color() = {Color.Green, Color.Yellow, _
        Color.Yellow, Color.Blue, Color.Red, Color.Red}
        Dim myPositions As Single() = {0.0F, 0.2F, 0.4F, 0.6F, 0.8F, 1.0F}
        Dim myBlend As New ColorBlend
        myBlend.Colors = myColors
        myBlend.Positions = myPositions
        Dim lgBrush2 As New LinearGradientBrush(startPoint2, endPoint2, _
        Color.Green, Color.Red)
        lgBrush2.InterpolationColors = myBlend
        Dim ellipseRect2 As New Rectangle(20, 110, 120, 80)
        e.Graphics.FillEllipse(lgBrush2, ellipseRect2)
    End Sub