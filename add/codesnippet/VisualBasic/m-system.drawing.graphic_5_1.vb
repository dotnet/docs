    Public Sub DrawLinesPoint(ByVal e As PaintEventArgs)

        ' Create pen.
        Dim blackPen As New Pen(Color.Black, 3)

        ' Create array of points that define lines to draw.
        Dim points As Point() = {New Point(10, 10), New Point(10, 100), _
        New Point(200, 50), New Point(250, 300)}

        'Draw lines to screen.
        e.Graphics.DrawLines(blackPen, points)
    End Sub