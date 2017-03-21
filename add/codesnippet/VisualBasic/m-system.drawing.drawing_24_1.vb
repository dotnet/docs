    Public Sub AddLinesExample(ByVal e As PaintEventArgs)

        'Create a symetrical triangle using an array of points.
        Dim myArray As Point() = {New Point(30, 30), New Point(60, 60), _
        New Point(0, 60), New Point(30, 30)}
        Dim myPath As New GraphicsPath
        myPath.AddLines(myArray)

        ' Draw the path to the screen.
        Dim myPen As New Pen(Color.Black, 2)
        e.Graphics.DrawPath(myPen, myPath)
    End Sub