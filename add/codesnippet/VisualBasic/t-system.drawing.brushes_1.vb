    Private Sub InstanceRectangleIntersection( _
        ByVal e As PaintEventArgs)

        Dim rectangle1 As New Rectangle(50, 50, 200, 100)
        Dim rectangle2 As New Rectangle(70, 20, 100, 200)
  
        e.Graphics.DrawRectangle(Pens.Black, rectangle1)
        e.Graphics.DrawRectangle(Pens.Red, rectangle2)

        If (rectangle1.IntersectsWith(rectangle2)) Then
            rectangle1.Intersect(rectangle2)
            If Not (rectangle1.IsEmpty) Then
                e.Graphics.FillRectangle(Brushes.Green, rectangle1)
            End If
        End If
    End Sub