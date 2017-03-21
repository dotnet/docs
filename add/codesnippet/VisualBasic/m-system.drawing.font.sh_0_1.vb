    Private Sub ConstructFontWithString(ByVal e As PaintEventArgs)
        Dim font1 As New Font("Arial", 20)
        e.Graphics.DrawString("Arial Font", font1, Brushes.Red, New PointF(10, 10))
    End Sub