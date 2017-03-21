    Private Sub OpAdditionExample(ByVal e As PaintEventArgs) 
        Dim size1 As New SizeF(120.5F, 30.5F)
        Dim point1 As New PointF(20.5F, 20F)
        Dim rect1 As New RectangleF(point1, size1)
        If New PointF(rect1.Right, rect1.Bottom) = point1 + size1 Then
            e.Graphics.DrawString("They are equal", Me.Font, Brushes.Black, rect1)
        Else
            e.Graphics.DrawString("They are not equal", Me.Font, Brushes.Red, rect1)
        End If
     
    End Sub