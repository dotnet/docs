    Public Sub TranslateExample(ByVal e As PaintEventArgs)
        Dim myPen As New Pen(Color.Blue, 1)
        Dim myPen2 As New Pen(Color.Red, 1)

        ' Draw a rectangle to the screen before applying the
        ' transform.
        e.Graphics.DrawRectangle(myPen, 20, 20, 100, 50)

        ' Create a matrix and translate it.
        Dim myMatrix As New Matrix
        myMatrix.Translate(100, 100, MatrixOrder.Append)

        ' Draw the Points to the screen again after applying the
        ' transform.
        e.Graphics.Transform = myMatrix
        e.Graphics.DrawRectangle(myPen2, 20, 20, 100, 50)
    End Sub