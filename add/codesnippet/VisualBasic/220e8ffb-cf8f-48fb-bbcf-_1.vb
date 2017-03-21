    Private Sub StaticRectangleIntersection(ByVal e As PaintEventArgs)
        Dim rectangle1 As New Rectangle(50, 50, 200, 100)
        Dim rectangle2 As New Rectangle(70, 20, 100, 200)
        Dim rectangle3 As New Rectangle

        e.Graphics.DrawRectangle(Pens.Black, rectangle1)
        e.Graphics.DrawRectangle(Pens.Red, rectangle2)

        If (rectangle1.IntersectsWith(rectangle2)) Then
            rectangle3 = Rectangle.Intersect(rectangle1, rectangle2)
            If Not rectangle3.IsEmpty Then
                e.Graphics.FillRectangle(Brushes.Green, rectangle3)
            End If
        End If
    End Sub