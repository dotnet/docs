    Private Sub IsVisible4Int(ByVal e As PaintEventArgs)

        ' Set clip region.
        Dim clipRegion As New [Region](New Rectangle(50, 50, 100, 100))
        e.Graphics.SetClip(clipRegion, CombineMode.Replace)

        ' Set up coordinates of rectangles.
        Dim x1 As Integer = 100
        Dim y1 As Integer = 100
        Dim width1 As Integer = 20
        Dim height1 As Integer = 20
        Dim x2 As Integer = 200
        Dim y2 As Integer = 200
        Dim width2 As Integer = 20
        Dim height2 As Integer = 20

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