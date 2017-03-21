    Public Sub FillPieRectangle(ByVal e As PaintEventArgs)

        ' Create solid brush.
        Dim redBrush As New SolidBrush(Color.Red)

        ' Create rectangle for ellipse.
        Dim rect As New Rectangle(0, 0, 200, 100)

        ' Create start and sweep angles.
        Dim startAngle As Single = 0.0F
        Dim sweepAngle As Single = 45.0F

        ' Fill pie to screen.
        e.Graphics.FillPie(redBrush, rect, startAngle, sweepAngle)
    End Sub