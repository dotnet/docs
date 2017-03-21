    Public Sub BlendConstExample(ByVal e As PaintEventArgs)

        ' Draw ellipse using Blend.
        Dim startPoint2 As New Point(20, 110)
        Dim endPoint2 As New Point(140, 110)
        Dim myFactors As Single() = {0.2F, 0.4F, 0.8F, 0.8F, 0.4F, 0.2F}
        Dim myPositions As Single() = {0.0F, 0.2F, 0.4F, 0.6F, 0.8F, 1.0F}
        Dim myBlend As New Blend
        myBlend.Factors = myFactors
        myBlend.Positions = myPositions
        Dim lgBrush2 As New LinearGradientBrush(startPoint2, endPoint2, _
        Color.Blue, Color.Red)
        lgBrush2.Blend = myBlend
        Dim ellipseRect2 As New Rectangle(20, 110, 120, 80)
        e.Graphics.FillEllipse(lgBrush2, ellipseRect2)
    End Sub