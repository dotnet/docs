    Private Sub IsVisibleRectangleF(ByVal e As PaintEventArgs)

        ' Set clip region.
        Dim clipRegion As New [Region](New Rectangle(50, 50, 100, 100))
        e.Graphics.SetClip(clipRegion, CombineMode.Replace)

        ' Set up coordinates of rectangles.
        Dim rect1 As New RectangleF(100.0F, 100.0F, 20.0F, 20.0F)
        Dim rect2 As New RectangleF(200.0F, 200.0F, 20.0F, 20.0F)

        ' If rectangle is visible, fill it.
        If e.Graphics.IsVisible(rect1) Then
            e.Graphics.FillRectangle(New SolidBrush(Color.Red), rect1)
        End If
        If e.Graphics.IsVisible(rect2) Then
            e.Graphics.FillRectangle(New SolidBrush(Color.Blue), rect2)
        End If
    End Sub