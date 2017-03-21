    Private Sub GetPixel_Example(ByVal e As PaintEventArgs)

        ' Create a Bitmap object from an image file.
        Dim myBitmap As New Bitmap("Grapes.jpg")

        ' Get the color of a pixel within myBitmap.
        Dim pixelColor As Color = myBitmap.GetPixel(50, 50)

        ' Fill a rectangle with pixelColor.
        Dim pixelBrush As New SolidBrush(pixelColor)
        e.Graphics.FillRectangle(pixelBrush, 0, 0, 100, 100)
    End Sub