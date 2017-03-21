    Public Sub MultiplyTransform_Example1(ByVal e As PaintEventArgs)

        ' Create a TextureBrush object.
        Dim tBrush As New TextureBrush(New Bitmap("texture.jpg"))

        ' Create a transformation matrix.
        Dim translateMatrix As New Matrix
        translateMatrix.Translate(50, 0)

        ' Multiply the transformation matrix of tBrush by translateMatrix.
        tBrush.MultiplyTransform(translateMatrix, MatrixOrder.Prepend)

        ' Fill a rectangle with tBrush.
        e.Graphics.FillRectangle(tBrush, 0, 110, 100, 100)
    End Sub