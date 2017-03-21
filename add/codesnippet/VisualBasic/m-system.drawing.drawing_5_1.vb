    Public Sub ResetExample(ByVal e As PaintEventArgs)
        Dim myPen As New Pen(Color.Blue, 1)
        Dim myPen2 As New Pen(Color.Red, 1)
        Dim myMatrix As New Matrix(5.0F, 0.0F, 0.0F, 3.0F, 0.0F, 0.0F)

        ListMatrixElementsHelper2(e, myMatrix, "Beginning Matrix", 6, 20)
        myMatrix.Reset()
        ListMatrixElementsHelper(e, myMatrix, "Matrix After Reset", 6, 40)

        ' Translate.
        myMatrix.Translate(50.0F, 40.0F)

        ListMatrixElementsHelper(e, myMatrix, "Matrix After Translation", _
            6, 60)
        e.Graphics.DrawRectangle(myPen, 0, 0, 100, 100)
        e.Graphics.Transform = myMatrix
        e.Graphics.DrawRectangle(myPen2, 0, 0, 100, 100)
    End Sub

    ' A helper function to list the contents of a matrix.
    Public Sub ListMatrixElementsHelper2(ByVal e As PaintEventArgs, _
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