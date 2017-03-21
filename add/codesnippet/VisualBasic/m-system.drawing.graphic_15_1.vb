    Private Sub IsVisibleInt(ByVal e As PaintEventArgs)

        ' Set clip region.
        Dim clipRegion As New [Region](New Rectangle(50, 50, 100, 100))
        e.Graphics.SetClip(clipRegion, CombineMode.Replace)

        ' Set up coordinates of points.
        Dim x1 As Integer = 100
        Dim y1 As Integer = 100
        Dim x2 As Integer = 200
        Dim y2 As Integer = 200

        ' If point is visible, fill ellipse that represents it.
        If e.Graphics.IsVisible(x1, y1) Then
            e.Graphics.FillEllipse(New SolidBrush(Color.Red), x1, y1, _
            10, 10)
        End If
        If e.Graphics.IsVisible(x2, y2) Then
            e.Graphics.FillEllipse(New SolidBrush(Color.Blue), x2, y2, _
            10, 10)
        End If
    End Sub