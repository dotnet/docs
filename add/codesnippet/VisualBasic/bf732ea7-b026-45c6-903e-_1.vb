    Private Sub MeasureStringPointFFormat(ByVal e As PaintEventArgs)

        ' Set up string.
        Dim measureString As String = "Measure String"
        Dim stringFont As New Font("Arial", 16)

        ' Set point for upper-left corner of string.
        Dim x As Single = 50.0F
        Dim y As Single = 50.0F
        Dim ulCorner As New PointF(x, y)

        ' Set string format.
        Dim newStringFormat As New StringFormat
        newStringFormat.FormatFlags = StringFormatFlags.DirectionVertical

        ' Measure string.
        Dim stringSize As New SizeF
        stringSize = e.Graphics.MeasureString(measureString, stringFont, _
        ulCorner, newStringFormat)

        ' Draw rectangle representing size of string.
        e.Graphics.DrawRectangle(New Pen(Color.Red, 1), x, y, _
        stringSize.Width, stringSize.Height)

        ' Draw string to screen.
        e.Graphics.DrawString(measureString, stringFont, Brushes.Black, _
        ulCorner, newStringFormat)
    End Sub