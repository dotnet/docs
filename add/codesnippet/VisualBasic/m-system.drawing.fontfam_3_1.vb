    Public Sub GetEmHeight_Example(ByVal e As PaintEventArgs)

        ' Create a FontFamily object.
        Dim emFontFamily As New FontFamily("arial")

        ' Get the em height of the font family in design units.
        Dim emHeight As Integer = _
        emFontFamily.GetEmHeight(FontStyle.Regular)

        ' Draw the result as a string to the screen.
        e.Graphics.DrawString("emFontFamily.GetEmHeight() returns " & _
        emHeight.ToString() + ".", New Font(emFontFamily, 16), _
        Brushes.Black, New PointF(0, 0))
    End Sub