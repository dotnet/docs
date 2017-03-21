    Private Sub ShowLineJoin(ByVal e As PaintEventArgs)

        ' Create a new pen.
        Dim skyBluePen As New Pen(Brushes.DeepSkyBlue)

        ' Set the pen's width.
        skyBluePen.Width = 8.0F

        ' Set the LineJoin property.
        skyBluePen.LineJoin = Drawing2D.LineJoin.Bevel

        ' Draw a rectangle.
        e.Graphics.DrawRectangle(skyBluePen, _
            New Rectangle(40, 40, 150, 200))

        'Dispose of the pen.
        skyBluePen.Dispose()

    End Sub