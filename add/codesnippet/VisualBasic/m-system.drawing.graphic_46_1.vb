    Private Sub DrawBeziersPoint(ByVal e As PaintEventArgs)

        ' Create pen.
        Dim blackPen As New Pen(Color.Black, 3)

        ' Create points for curve.
        Dim start As New Point(100, 100)
        Dim control1 As New Point(200, 10)
        Dim control2 As New Point(350, 50)
        Dim end1 As New Point(500, 100)
        Dim control3 As New Point(600, 150)
        Dim control4 As New Point(650, 250)
        Dim end2 As New Point(500, 300)
        Dim bezierPoints As Point() = {start, control1, control2, _
        end1, control3, control4, end2}

        ' Draw arc to screen.
        e.Graphics.DrawBeziers(blackPen, bezierPoints)
    End Sub