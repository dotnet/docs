    Public Sub ScaleExample(ByVal e As PaintEventArgs)
        Dim myPen As New Pen(Color.Blue, 1)
        Dim myPen2 As New Pen(Color.Red, 1)

        ' Draw the rectangle to the screen before applying the
        ' transform.
        e.Graphics.DrawRectangle(myPen, 50, 50, 100, 100)

        ' Create a matrix and scale it.
        Dim myMatrix As New Matrix
        myMatrix.Scale(3, 2, MatrixOrder.Append)

        ' Draw the rectangle to the screen again after applying the
        ' transform.
        e.Graphics.Transform = myMatrix
        e.Graphics.DrawRectangle(myPen2, 50, 50, 100, 100)
    End Sub