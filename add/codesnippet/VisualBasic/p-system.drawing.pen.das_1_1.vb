    Private Sub ShowPensAndSmoothingMode(ByVal e As PaintEventArgs)

        ' Set the SmoothingMode property to smooth the line.
        e.Graphics.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias

        ' Create a new Pen object.
        Dim greenPen As New Pen(Color.Green)

        ' Set the width to 6.
        greenPen.Width = 6.0F

        ' Set the DashCap to round.
        greenPen.DashCap = Drawing2D.DashCap.Round

        ' Create a custom dash pattern.
        greenPen.DashPattern = New Single() {4.0F, 2.0F, 1.0F, 3.0F}

        ' Draw a line.
        e.Graphics.DrawLine(greenPen, 20.0F, 20.0F, 100.0F, 240.0F)

        ' Change the SmoothingMode to none.
        e.Graphics.SmoothingMode = Drawing2D.SmoothingMode.None

        ' Draw another line.
        e.Graphics.DrawLine(greenPen, 100.0F, 240.0F, 160.0F, 20.0F)

        ' Dispose of the custom pen.
        greenPen.Dispose()
    End Sub