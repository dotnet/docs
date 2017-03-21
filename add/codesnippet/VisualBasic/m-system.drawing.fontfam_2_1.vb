    Public Sub GetLineSpacing_Example(ByVal e As PaintEventArgs)

        ' Create a FontFamily object.
        Dim myFontFamily As New FontFamily("Arial")

        ' Get the line spacing for myFontFamily.
        Dim lineSpacing As Integer = _
        myFontFamily.GetLineSpacing(FontStyle.Regular)

        ' Draw the value of lineSpacing to the screen as a string.
        e.Graphics.DrawString("lineSpacing = " & lineSpacing.ToString(), _
        New Font(myFontFamily, 16), Brushes.Black, New PointF(0, 0))
    End Sub