    Public Sub MultiplyExample(ByVal e As PaintEventArgs)
        Dim myPen As New Pen(Color.Blue, 1)
        Dim myPen2 As New Pen(Color.Red, 1)

        ' Set up the matrices.
        Dim myMatrix1 As New Matrix(2.0F, 0.0F, 0.0F, 1.0F, 0.0F, 0.0F)

        ' Scale.
        Dim myMatrix2 As New Matrix(0.0F, 1.0F, -1.0F, 0.0F, 0.0F, 0.0F)

        ' Rotate 90.
        Dim myMatrix3 As New Matrix(1.0F, 0.0F, 0.0F, 1.0F, 250.0F, 50.0F)

        ' Display the elements of the starting matrix.
        ListMatrixElementsHelper(e, myMatrix1, "Beginning Matrix", 6, 40)

        ' Multiply Matrix1 by Matrix 2.
        myMatrix1.Multiply(myMatrix2, MatrixOrder.Append)

        ' Display the result of the multiplication of Matrix1 and
        ' Matrix2.
        ListMatrixElementsHelper(e, myMatrix1, _
        "Matrix After 1st Multiplication", 6, 60)

        ' Multiply the result from the pervious multiplication by
        ' Matrix3.
        myMatrix1.Multiply(myMatrix3, MatrixOrder.Append)

        ' Display the result of the previous multiplication
        ' multiplied by Matrix3.
        ListMatrixElementsHelper1(e, myMatrix1, _
        "Matrix After 2nd Multiplication", 6, 80)

        ' Draw the rectangle prior to transformation.
        e.Graphics.DrawRectangle(myPen, 0, 0, 100, 100)
        e.Graphics.Transform = myMatrix1

        ' Draw the rectangle after transformation.
        e.Graphics.DrawRectangle(myPen2, 0, 0, 100, 100)
    End Sub

    ' A helper function to list the contents of a matrix.
    Public Sub ListMatrixElementsHelper1(ByVal e As PaintEventArgs, _
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