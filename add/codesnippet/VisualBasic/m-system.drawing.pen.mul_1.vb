    Public Sub MultiplyTransform_Example1(ByVal e As PaintEventArgs)

        ' Create a Pen object.
        Dim myPen As New Pen(Color.Black, 5)

        ' Create a translation matrix.
        Dim penMatrix As New Matrix
        penMatrix.Scale(3, 1)

        ' Multiply the transformation matrix of myPen by transMatrix.
        myPen.MultiplyTransform(penMatrix)

        ' Draw a line to the screen.
        e.Graphics.DrawLine(myPen, 0, 0, 100, 100)
    End Sub