    Private Sub GetNearestColorColor(ByVal e As PaintEventArgs)

        ' Create solid brush with arbitrary color.
        Dim arbColor As Color = Color.FromArgb(255, 165, 63, 136)
        Dim arbBrush As New SolidBrush(arbColor)

        ' Fill ellipse on screen.
        e.Graphics.FillEllipse(arbBrush, 0, 0, 200, 100)

        ' Get nearest color.
        Dim realColor As Color = e.Graphics.GetNearestColor(arbColor)
        Dim realBrush As New SolidBrush(realColor)

        ' Fill ellipse on screen.
        e.Graphics.FillEllipse(realBrush, 0, 100, 200, 100)
    End Sub