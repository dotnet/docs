    Public Sub FromOle_Example(ByVal e As PaintEventArgs)

        ' Create an integer representation of an HTML color.
        Dim oleColor As Integer = &HFF00

        ' Translate oleColor to a GDI+ Color structure.
        Dim myColor As Color = ColorTranslator.FromOle(oleColor)

        ' Fill a rectangle with myColor.
        e.Graphics.FillRectangle(New SolidBrush(myColor), 0, 0, 100, 100)
    End Sub