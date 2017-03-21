    Public Sub GetCellDescent_Example(ByVal e As PaintEventArgs)

        ' Create a FontFamily object.
        Dim descentFontFamily As New FontFamily("arial")

        ' Get the cell descent of the font family in design units.
        Dim cellDescent As Integer = _
        descentFontFamily.GetCellDescent(FontStyle.Regular)

        ' Draw the result as a string to the screen.
        e.Graphics.DrawString("descentFontFamily.GetCellDescent() returns " _
        & cellDescent.ToString() & ".", New Font(descentFontFamily, 16), _
        Brushes.Black, New PointF(0, 0))
    End Sub