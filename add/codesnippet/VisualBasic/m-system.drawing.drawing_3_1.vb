    Public Sub MatrixShearExample(ByVal e As PaintEventArgs)
        Dim myMatrix As New Matrix
        myMatrix.Shear(2, 0)
        e.Graphics.DrawRectangle(New Pen(Color.Green), 0, 0, 100, 50)
        e.Graphics.MultiplyTransform(myMatrix)
        e.Graphics.DrawRectangle(New Pen(Color.Red), 0, 0, 100, 50)
        e.Graphics.DrawEllipse(New Pen(Color.Blue), 0, 0, 100, 50)
    End Sub