    Public Sub FillEllipseFloat(ByVal e As PaintEventArgs)

        ' Create solid brush.
        Dim redBrush As New SolidBrush(Color.Red)

        ' Create location and size of ellipse.
        Dim x As Single = 0.0F
        Dim y As Single = 0.0F
        Dim width As Single = 200.0F
        Dim height As Single = 100.0F

        ' Fill ellipse on screen.
        e.Graphics.FillEllipse(redBrush, x, y, width, height)
    End Sub