    Private Sub DrawWithGradientActiveCaptionPen(ByVal e As PaintEventArgs) 
        Dim rectangle1 As New Rectangle(10, 10, 100, 100)
        e.Graphics.DrawRectangle(SystemPens.GradientActiveCaption, rectangle1)
    
    End Sub
    