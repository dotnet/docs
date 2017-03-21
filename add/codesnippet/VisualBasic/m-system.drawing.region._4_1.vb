    Public Sub GetBoundsExample(ByVal e As PaintEventArgs)

        ' Create a GraphicsPath and add an ellipse to it.
        Dim myPath As New GraphicsPath
        Dim ellipseRect As New Rectangle(20, 20, 100, 100)
        myPath.AddEllipse(ellipseRect)

        ' Fill the path with blue and draw it to the screen.
        Dim myBrush As New SolidBrush(Color.Blue)
        e.Graphics.FillPath(myBrush, myPath)

        ' Create a region using the GraphicsPath.
        Dim myRegion As New [Region](myPath)

        ' Get the bounding rectangle for myRegion and draw it to the
        ' screen in Red.
        Dim boundsRect As RectangleF = myRegion.GetBounds(e.Graphics)
        e.Graphics.DrawRectangle(Pens.Red, Rectangle.Round(boundsRect))
    End Sub