    Public Sub FillEllipseInt(ByVal e As PaintEventArgs)

        ' Create solid brush.
        Dim redBrush As New SolidBrush(Color.Red)

        ' Create location and size of ellipse.
        Dim x As Integer = 0
        Dim y As Integer = 0
        Dim width As Integer = 200
        Dim height As Integer = 100

        ' Fill ellipse on screen.
        e.Graphics.FillEllipse(redBrush, x, y, width, height)
    End Sub