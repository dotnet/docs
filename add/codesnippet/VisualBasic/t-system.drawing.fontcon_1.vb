    Private Sub ShowFontStringConversion(ByVal e As PaintEventArgs)

        ' Create the FontConverter.
        Dim converter As System.ComponentModel.TypeConverter = _
            System.ComponentModel.TypeDescriptor.GetConverter(GetType(Font))

        Dim font1 As Font = _
            CType(converter.ConvertFromString("Arial, 12pt"), Font)

        Dim fontName1 As String = _
            converter.ConvertToInvariantString(font1)
        Dim fontName2 As String = converter.ConvertToString(font1)

        e.Graphics.DrawString(fontName1, font1, Brushes.Red, 10, 10)
        e.Graphics.DrawString(fontName2, font1, Brushes.Blue, 10, 30)
    End Sub