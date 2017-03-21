    Public Sub AddBeziersExample(ByVal e As PaintEventArgs)

        ' Adds two Bezier curves.
        Dim myArray As Point() = {New Point(20, 100), New Point(40, 75), _
        New Point(60, 125), New Point(80, 100), New Point(100, 50), _
        New Point(120, 150), New Point(140, 100)}
        Dim myPath As New GraphicsPath
        myPath.AddBeziers(myArray)
        Dim myPen As New Pen(Color.Black, 2)
        e.Graphics.DrawPath(myPen, myPath)
    End Sub