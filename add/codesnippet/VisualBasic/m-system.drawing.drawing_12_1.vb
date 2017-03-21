    Public Sub TransformVectorsExample(ByVal e As PaintEventArgs)
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
        myMatrix.Translate(100, 100, MatrixOrder.Append)
        ListMatrixElementsHelper(e, myMatrix, _
        "Scaled and Translated Matrix", 6, 20)
        myMatrix.TransformVectors(myArray)

        ' Draw the Points to the screen again after applying the
        ' transform.
        e.Graphics.DrawLines(myPen2, myArray)
    End Sub

    ' A helper function to list the contents of a matrix.
    Public Sub ListMatrixElementsHelper(ByVal e As PaintEventArgs, _
    ByVal matrix As Matrix, ByVal matrixName As String, ByVal numElements As Integer, _
    ByVal y As Integer)

        ' Set up variables for drawing the array
        ' of points to the screen.
        Dim i As Integer
        Dim x As Single = 20
        Dim j As Single = 200
        Dim myFont As New Font("Arial", 8)
        Dim myBrush As New SolidBrush(Color.Black)

        ' Draw the matrix name to the screen.
        e.Graphics.DrawString(matrixName + ":  ", myFont, myBrush, x, y)

        ' Draw the set of path points and types to the screen.
        For i = 0 To numElements - 1
            e.Graphics.DrawString(matrix.Elements(i).ToString() + ", ", _
            myFont, myBrush, j, y)
            j += 30
        Next i
    End Sub