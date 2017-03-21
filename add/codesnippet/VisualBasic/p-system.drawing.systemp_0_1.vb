    Private Sub DrawWithGrayTextPen(ByVal e As PaintEventArgs) 
        Dim rectangle1 As New Rectangle(10, 10, 100, 100)
        e.Graphics.DrawRectangle(SystemPens.GrayText, rectangle1)
    
    End Sub
    