    Public Sub AddPathExample(ByVal e As PaintEventArgs)

        ' Creates a symetrical triangle and adds an inverted triangle.

        ' Create the first path - right side up triangle.
        Dim myArray As Point() = {New Point(30, 30), New Point(60, 60), _
        New Point(0, 60), New Point(30, 30)}
        Dim myPath As New GraphicsPath
        myPath.AddLines(myArray)

        ' Create the second path - inverted triangle.
        Dim myArray2 As Point() = {New Point(30, 30), New Point(0, 0), _
        New Point(60, 0), New Point(30, 30)}
        Dim myPath2 As New GraphicsPath
        myPath2.AddLines(myArray2)

        ' Add the second path to the first path.
        myPath.AddPath(myPath2, True)

        ' Draw the combined path to the screen.
        Dim myPen As New Pen(Color.Black, 2)
        e.Graphics.DrawPath(myPen, myPath)
    End Sub