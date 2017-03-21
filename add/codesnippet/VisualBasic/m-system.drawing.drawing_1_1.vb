    Public Sub TransformPointsExample(ByVal e As PaintEventArgs)
        Dim myPen As New Pen(Color.Blue, 1)
        Dim myPen2 As New Pen(Color.Red, 1)

        ' Create an array of points.
        Dim myArray As Point() = {New Point(20, 20), New Point(120, 20), _
        New Point(120, 120), New Point(20, 120), New Point(20, 20)}

        ' Draw the Points to the screen before applying the
        ' transform.
        e.Graphics.DrawLines(myPen, myArray)

        ' Create a matrix and scale it.
        Dim myMatrix As New Matrix
        myMatrix.Scale(3, 2, MatrixOrder.Append)
        myMatrix.TransformPoints(myArray)

        ' Draw the Points to the screen again after applying the
        ' transform.
        e.Graphics.DrawLines(myPen2, myArray)
    End Sub