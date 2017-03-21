    Public Sub AddRectangleExample(ByVal e As PaintEventArgs)

        ' Create a GraphicsPath object and add a rectangle to it.
        Dim myPath As New GraphicsPath
        Dim pathRect As New Rectangle(20, 20, 100, 200)
        myPath.AddRectangle(pathRect)

        ' Draw the path to the screen.
        Dim myPen As New Pen(Color.Black, 2)
        e.Graphics.DrawPath(myPen, myPath)
    End Sub