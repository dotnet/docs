    Public Sub DrawStringRectangleF(ByVal e As PaintEventArgs)

        ' Create string to draw.
        Dim drawString As [String] = "Sample Text"

        ' Create font and brush.
        Dim drawFont As New Font("Arial", 16)
        Dim drawBrush As New SolidBrush(Color.Black)

        ' Create rectangle for drawing.
        Dim x As Single = 150.0F
        Dim y As Single = 150.0F
        Dim width As Single = 200.0F
        Dim height As Single = 50.0F
        Dim drawRect As New RectangleF(x, y, width, height)

        ' Draw rectangle to screen.
        Dim blackPen As New Pen(Color.Black)
        e.Graphics.DrawRectangle(blackPen, x, y, width, height)

        ' Draw string to screen.
        e.Graphics.DrawString(drawString, drawFont, drawBrush, drawRect)
    End Sub