    Private Sub IsVisibleFloat(ByVal e As PaintEventArgs)

        ' Set clip region.
        Dim clipRegion As New [Region](New Rectangle(50, 50, 100, 100))
        e.Graphics.SetClip(clipRegion, CombineMode.Replace)

        ' Set up coordinates of points.
        Dim x1 As Single = 100.0F
        Dim y1 As Single = 100.0F
        Dim x2 As Single = 200.0F
        Dim y2 As Single = 200.0F

        ' If point is visible, fill ellipse that represents it.
        If e.Graphics.IsVisible(x1, y1) Then
            e.Graphics.FillEllipse(New SolidBrush(Color.Red), x1, y1, _
            10.0F, 10.0F)
        End If
        If e.Graphics.IsVisible(x2, y2) Then
            e.Graphics.FillEllipse(New SolidBrush(Color.Blue), x2, y2, _
            10.0F, 10.0F)
        End If
    End Sub