    Private Sub OpSubtractionExample(ByVal e As PaintEventArgs) 
        Dim point1 As New PointF(120.5F, 120F)
        Dim size1 As New SizeF(120.5F, 30.5F)
        Dim point2 As PointF = point1 - size1
        e.Graphics.DrawLine(Pens.Blue, point1, point2)
    
    End Sub