    Public Sub ResetTransform_Example(ByVal e As PaintEventArgs)

        ' Create a TextureBrush object.
        Dim tBrush As New TextureBrush(New Bitmap("texture.jpg"))

        ' Rotate the texture image by 90 degrees.
        tBrush.RotateTransform(90)

        ' Fill a rectangle with tBrush.
        e.Graphics.FillRectangle(tBrush, 0, 0, 100, 100)

        ' Reset transformation matrix to identity.
        tBrush.ResetTransform()

        ' Fill a rectangle with tBrush.
        e.Graphics.FillRectangle(tBrush, 0, 110, 100, 100)
    End Sub
    'ResetTransform_Example.