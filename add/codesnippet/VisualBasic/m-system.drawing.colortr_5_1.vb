    Public Sub FromHtml_Example(ByVal e As PaintEventArgs)

        ' Create a string representation of an HTML color.
        Dim htmlColor As String = "Blue"

        ' Translate htmlColor to a GDI+ Color structure.
        Dim myColor As Color = ColorTranslator.FromHtml(htmlColor)

        ' Fill a rectangle with myColor.
        e.Graphics.FillRectangle(New SolidBrush(myColor), 0, 0, 100, 100)
    End Sub