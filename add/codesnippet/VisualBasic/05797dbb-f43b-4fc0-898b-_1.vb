    Public Sub SetMeasCharRangesExample(ByVal e As PaintEventArgs)
        Dim g As Graphics = e.Graphics
        Dim redBrush As New SolidBrush(Color.FromArgb(50, 255, 0, 0))

        ' Layout rectangles, font, and string format used for
        ' displaying string.
        Dim layoutRectA As New Rectangle(20, 20, 165, 80)
        Dim layoutRectB As New Rectangle(20, 110, 165, 80)
        Dim layoutRectC As New Rectangle(20, 200, 240, 80)
        Dim tnrFont As New Font("Times New Roman", 16)
        Dim strFormat As New StringFormat

        ' Ranges of character positions within a string.
        Dim charRanges As CharacterRange() = {New CharacterRange(3, 5), _
        New CharacterRange(15, 2), New CharacterRange(30, 15)}

        ' Each region specifies the area occupied by the characters within
        ' a range of positions. The values are obtained by using a method
        ' that measures the character ranges.
        Dim charRegions(charRanges.Length) As [Region]

        ' String to be displayed.
        Dim str As String = _
        "The quick, brown fox easily jumps over the lazy dog."

        ' Set the char ranges for the string format.
        strFormat.SetMeasurableCharacterRanges(charRanges)

        ' Loop counter (unsigned 8-bit integer).
        Dim i As Byte


        ' Measure the char ranges for a given string and layout rectangle.
        ' Each area occupied by the characters in a range is stored as a
        ' region. then draw the string and layout rectangle and paint the
        ' regions.
        charRegions = g.MeasureCharacterRanges(str, tnrFont, _
        RectangleF.op_Implicit(layoutRectA), strFormat)
        g.DrawString(str, tnrFont, Brushes.Blue, _
        RectangleF.op_Implicit(layoutRectA), strFormat)
        g.DrawRectangle(Pens.Black, layoutRectA)

        ' Paint the regions.
        For i = 0 To charRegions.Length - 1
            g.FillRegion(redBrush, charRegions(i))
        Next i

        ' Repeat the above steps, but include trailing spaces in the char
        ' range measurement by setting the appropriate string format flag.
        strFormat.FormatFlags = StringFormatFlags.MeasureTrailingSpaces
        charRegions = g.MeasureCharacterRanges(str, tnrFont, _
        RectangleF.op_Implicit(layoutRectB), strFormat)
        g.DrawString(str, tnrFont, Brushes.Blue, _
        RectangleF.op_Implicit(layoutRectB), strFormat)
        g.DrawRectangle(Pens.Black, layoutRectB)

        ' Paint the regions.
        For i = 0 To charRegions.Length - 1
            g.FillRegion(redBrush, charRegions(i))
        Next i

        ' Clear all the format flags.
        strFormat.FormatFlags = 0

        ' Repeat the steps, but use a different layout rectangle. The
        ' dimensions of the layout rectangle and the size of the font both
        ' affect the character range measurement.
        charRegions = g.MeasureCharacterRanges(str, tnrFont, _
        RectangleF.op_Implicit(layoutRectC), strFormat)
        g.DrawString(str, tnrFont, Brushes.Blue, _
        RectangleF.op_Implicit(layoutRectC), strFormat)
        g.DrawRectangle(Pens.Black, layoutRectC)

        ' Paint the regions.
        For i = 0 To charRegions.Length - 1
            g.FillRegion(redBrush, charRegions(i))
        Next i
    End Sub