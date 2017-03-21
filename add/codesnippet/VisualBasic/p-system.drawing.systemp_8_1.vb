    Private Sub DrawWithInactiveBorderPen(ByVal e As PaintEventArgs) 
        Dim rectangle1 As New Rectangle(10, 10, 100, 100)
        e.Graphics.DrawRectangle(SystemPens.InactiveBorder, rectangle1)
    
    End Sub
    