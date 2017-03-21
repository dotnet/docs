    Private Sub DrawWithActiveCaptionPen(ByVal e As PaintEventArgs) 
        Dim rectangle1 As New Rectangle(10, 10, 100, 100)
        e.Graphics.DrawRectangle(SystemPens.ActiveCaption, rectangle1)
    
    End Sub
    