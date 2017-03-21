    Private Sub HighlightACharacterRange(ByVal e As PaintEventArgs)

        ' Declare the string to draw.
        Dim message As String = _
            "This is the string to highlight a word in."

        ' Declare the word to highlight.
        Dim searchWord As String = "string"

        ' Create a CharacterRange array with the searchWord 
        ' location and length.
        Dim ranges() As CharacterRange = _
            New CharacterRange() _
                {New CharacterRange(message.IndexOf(searchWord), _
                searchWord.Length)}

        ' Construct a StringFormat object.
        Dim stringFormat1 As New StringFormat

        ' Set the ranges on the StringFormat object.
        stringFormat1.SetMeasurableCharacterRanges(ranges)

        ' Declare the font to write the message in.
        Dim largeFont As Font = New Font(FontFamily.GenericSansSerif, _
            16.0F, GraphicsUnit.Pixel)

        ' Construct a new Rectangle.
        Dim displayRectangle As New Rectangle(20, 20, 200, 100)

        ' Convert the Rectangle to a RectangleF.
        Dim displayRectangleF As RectangleF = _
            RectangleF.op_Implicit(displayRectangle)

        ' Get the Region to highlight by calling the 
        ' MeasureCharacterRanges method.
        Dim charRegion() As Region = _
            e.Graphics.MeasureCharacterRanges(message, _
            largeFont, displayRectangleF, stringFormat1)

        ' Draw the message string on the form.
        e.Graphics.DrawString(message, largeFont, Brushes.Blue, _
            displayRectangleF)

        ' Fill in the region using a semi-transparent color.
        e.Graphics.FillRegion(New SolidBrush(Color.FromArgb(50, _
            Color.Fuchsia)), charRegion(0))

    End Sub