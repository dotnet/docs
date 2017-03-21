    Public Sub DrawRectangleInt(ByVal e As PaintEventArgs)

        ' Create pen.
        Dim blackPen As New Pen(Color.Black, 3)

        ' Create location and size of rectangle.
        Dim x As Integer = 0
        Dim y As Integer = 0
        Dim width As Integer = 200
        Dim height As Integer = 200

        ' Draw rectangle to screen.
        e.Graphics.DrawRectangle(blackPen, x, y, width, height)
    End Sub