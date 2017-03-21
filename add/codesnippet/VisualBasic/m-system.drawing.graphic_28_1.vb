    Private Sub IsVisibleRectangle(ByVal e As PaintEventArgs)

        ' Set clip region.
        Dim clipRegion As New [Region](New Rectangle(50, 50, 100, 100))
        e.Graphics.SetClip(clipRegion, CombineMode.Replace)

        ' Set up coordinates of rectangles.
        Dim rect1 As New Rectangle(100, 100, 20, 20)
        Dim rect2 As New Rectangle(200, 200, 20, 20)

        ' If rectangle is visible, fill it.
        If e.Graphics.IsVisible(rect1) Then
            e.Graphics.FillRectangle(New SolidBrush(Color.Red), rect1)
        End If
        If e.Graphics.IsVisible(rect2) Then
            e.Graphics.FillRectangle(New SolidBrush(Color.Blue), rect2)
        End If
    End Sub