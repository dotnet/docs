    Private Sub AddPoint(ByVal e As PaintEventArgs) 
        Dim point1 As New Point(10, 10)
        Dim point2 As Point = Point.Add(point1, New Size(250, 0))
        e.Graphics.DrawLine(Pens.Red, point1, point2)
    
    End Sub