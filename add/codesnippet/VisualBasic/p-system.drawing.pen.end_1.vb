    Private Sub ShowStartAndEndCaps(ByVal e As PaintEventArgs)

        ' Create a new custom pen.
        Dim redPen As New Pen(Brushes.Red, 6.0F)

        ' Set the StartCap property.
        redPen.StartCap = Drawing2D.LineCap.RoundAnchor

        ' Set the EndCap property.
        redPen.EndCap = Drawing2D.LineCap.ArrowAnchor

        ' Draw a line.
        e.Graphics.DrawLine(redPen, 40.0F, 40.0F, 145.0F, 185.0F)

        ' Dispose of the custom pen.
        redPen.Dispose()

    End Sub