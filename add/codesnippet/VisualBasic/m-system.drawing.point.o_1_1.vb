    Private Sub OffsetPoint(ByVal e As PaintEventArgs) 
        Dim point1 As New Point(10, 10)
        point1.Offset(50, 0)
        Dim point2 As New Point(250, 10)
        e.Graphics.DrawLine(Pens.Red, point1, point2)
    End Sub