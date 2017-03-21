    Public Sub GetCellAscent_Example(ByVal e As PaintEventArgs)

        ' Create a FontFamily object.
        Dim ascentFontFamily As New FontFamily("arial")

        ' Get the cell ascent of the font family in design units.
        Dim cellAscent As Integer = _
        ascentFontFamily.GetCellAscent(FontStyle.Regular)

        ' Draw the result as a string to the screen.
        e.Graphics.DrawString("ascentFontFamily.GetCellAscent() returns " _
        & cellAscent.ToString() & ".", New Font(ascentFontFamily, 16), _
        Brushes.Black, New PointF(0, 0))
    End Sub