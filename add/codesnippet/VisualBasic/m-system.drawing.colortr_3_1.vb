    Public Sub FromWin32_Example(ByVal e As PaintEventArgs)

        ' Create an integer representation of a Win32 color.
        Dim winColor As Integer = &HA000

        ' Translate winColor to a GDI+ Color structure.
        Dim myColor As Color = ColorTranslator.FromWin32(winColor)

        ' Fill a rectangle with myColor.
        e.Graphics.FillRectangle(New SolidBrush(myColor), 0, 0, 100, 100)
    End Sub