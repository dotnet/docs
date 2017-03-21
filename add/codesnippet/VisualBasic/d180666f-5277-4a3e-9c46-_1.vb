    Public Sub DrawStringFloatFormat(ByVal e As PaintEventArgs)

        ' Create string to draw.
        Dim drawString As [String] = "Sample Text"

        ' Create font and brush.
        Dim drawFont As New Font("Arial", 16)
        Dim drawBrush As New SolidBrush(Color.Black)

        ' Create point for upper-left corner of drawing.
        Dim x As Single = 150.0F
        Dim y As Single = 50.0F

        ' Set format of string.
        Dim drawFormat As New StringFormat
        drawFormat.FormatFlags = StringFormatFlags.DirectionVertical

        ' Draw string to screen.
        e.Graphics.DrawString(drawString, drawFont, drawBrush, _
        x, y, drawFormat)
    End Sub