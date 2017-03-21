    Public Sub TranslateTransform_Example2(ByVal e As PaintEventArgs)

        ' Create a TextureBrush object.
        Dim tBrush As New TextureBrush(New Bitmap("texture.jpg"))

        ' Move the texture image 2X in the x-direction.
        tBrush.TranslateTransform(50, 0)

        ' Fill a rectangle with tBrush.
        e.Graphics.FillRectangle(tBrush, 0, 0, 100, 100)
    End Sub