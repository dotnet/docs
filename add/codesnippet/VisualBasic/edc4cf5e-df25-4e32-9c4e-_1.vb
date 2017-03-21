    Private Sub MeasureCharacterRangesRegions(ByVal e As PaintEventArgs)

        ' Set up string.
        Dim measureString As String = "First and Second ranges"
        Dim stringFont As New Font("Times New Roman", 16.0F)

        ' Set character ranges to "First" and "Second".
        Dim characterRanges As CharacterRange() = _
        {New CharacterRange(0, 5), New CharacterRange(10, 6)}

        ' Create rectangle for layout.
        Dim x As Single = 50.0F
        Dim y As Single = 50.0F
        Dim width As Single = 35.0F
        Dim height As Single = 200.0F
        Dim layoutRect As New RectangleF(x, y, width, height)

        ' Set string format.
        Dim stringFormat As New StringFormat
        stringFormat.FormatFlags = StringFormatFlags.DirectionVertical
        stringFormat.SetMeasurableCharacterRanges(characterRanges)

        ' Draw string to screen.
        e.Graphics.DrawString(measureString, stringFont, Brushes.Black, _
        x, y, stringFormat)

        ' Measure two ranges in string.
        Dim stringRegions() As [Region] = e.Graphics.MeasureCharacterRanges(measureString, _
	stringFont, layoutRect, stringFormat)

        ' Draw rectangle for first measured range.
        Dim measureRect1 As RectangleF = _
        stringRegions(0).GetBounds(e.Graphics)
        e.Graphics.DrawRectangle(New Pen(Color.Red, 1), _
        Rectangle.Round(measureRect1))

        ' Draw rectangle for second measured range.
        Dim measureRect2 As RectangleF = _
        stringRegions(1).GetBounds(e.Graphics)
        e.Graphics.DrawRectangle(New Pen(Color.Blue, 1), _
        Rectangle.Round(measureRect2))
    End Sub