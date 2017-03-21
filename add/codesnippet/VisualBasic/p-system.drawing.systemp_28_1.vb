    Private Sub DrawWithInactiveCaptionTextPen(ByVal e As PaintEventArgs) 
        Dim rectangle1 As New Rectangle(10, 10, 100, 100)
        e.Graphics.DrawRectangle(SystemPens.InactiveCaptionText, rectangle1)
    
    End Sub
    