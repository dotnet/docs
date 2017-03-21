    Private Sub IsVisible4Float(ByVal e As PaintEventArgs)

        ' Set clip region.
        Dim clipRegion As New [Region](New Rectangle(50, 50, 100, 100))
        e.Graphics.SetClip(clipRegion, CombineMode.Replace)

        ' Set up coordinates of rectangles.
        Dim x1 As Single = 100.0F
        Dim y1 As Single = 100.0F
        Dim width1 As Single = 20.0F
        Dim height1 As Single = 20.0F
        Dim x2 As Single = 200.0F
        Dim y2 As Single = 200.0F
        Dim width2 As Single = 20.0F
        Dim height2 As Single = 20.0F

        ' If rectangle is visible, fill it.
        If e.Graphics.IsVisible(x1, y1, width1, height1) Then
            e.Graphics.FillRectangle(New SolidBrush(Color.Red), x1, y1, _
            width1, height1)
        End If
        If e.Graphics.IsVisible(x2, y2, width2, height2) Then
            e.Graphics.FillRectangle(New SolidBrush(Color.Blue), x2, y2, _
            width2, height2)
        End If
    End Sub