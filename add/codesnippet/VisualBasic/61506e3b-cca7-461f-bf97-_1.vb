    Public Sub FromArgb1(ByVal e As PaintEventArgs)
        Dim g As Graphics = e.Graphics

        ' Transparent red, green, and blue brushes.
        Dim trnsRedBrush As New SolidBrush(Color.FromArgb(120, 255, 0, 0))
        Dim trnsGreenBrush As New SolidBrush(Color.FromArgb(120, 0, _
        255, 0))
        Dim trnsBlueBrush As New SolidBrush(Color.FromArgb(120, 0, 0, 255))

        ' Base and height of the triangle that is used to position the
        ' circles. Each vertex of the triangle is at the center of one of
        ' the 3 circles. The base is equal to the diameter of the circle.
        Dim triBase As Single = 100
        Dim triHeight As Single = CSng(Math.Sqrt((3 * (triBase * _
        triBase) / 4)))

        ' Coordinates of first circle's bounding rectangle.
        Dim x1 As Single = 40
        Dim y1 As Single = 40

        ' Fill 3 over-lapping circles. Each circle is a different color.
        g.FillEllipse(trnsRedBrush, x1, y1, 2 * triHeight, 2 * triHeight)
        g.FillEllipse(trnsGreenBrush, x1 + triBase / 2, y1 + triHeight, _
        2 * triHeight, 2 * triHeight)
        g.FillEllipse(trnsBlueBrush, x1 + triBase, y1, 2 * triHeight, _
        2 * triHeight)
    End Sub