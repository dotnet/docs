    Public Sub DrawStringPointF(ByVal e As PaintEventArgs)

        ' Create string to draw.
        Dim drawString As [String] = "Sample Text"

        ' Create font and brush.
        Dim drawFont As New Font("Arial", 16)
        Dim drawBrush As New SolidBrush(Color.Black)

        ' Create point for upper-left corner of drawing.
        Dim drawPoint As New PointF(150.0F, 150.0F)

        ' Draw string to screen.
        e.Graphics.DrawString(drawString, drawFont, drawBrush, drawPoint)
    End Sub