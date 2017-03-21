    Public Sub SetColorMatrixExample(ByVal e As PaintEventArgs)

        ' Create a rectangle image with all colors set to 128 (medium

        ' gray).
        Dim myBitmap As New Bitmap(50, 50, PixelFormat.Format32bppArgb)
        Dim g As Graphics = Graphics.FromImage(myBitmap)
        g.FillRectangle(New SolidBrush(Color.FromArgb(255, 128, 128, _
        128)), New Rectangle(0, 0, 50, 50))
        myBitmap.Save("Rectangle1.jpg")

        ' Open an Image file and draw it to the screen.
        Dim myImage As Image = Image.FromFile("Rectangle1.jpg")
        e.Graphics.DrawImage(myImage, 20, 20)

        ' Initialize the color matrix.
        Dim myColorMatrix As New ColorMatrix
        myColorMatrix.Matrix00 = 1.75F
        ' Red
        myColorMatrix.Matrix11 = 1.0F
        ' Green
        myColorMatrix.Matrix22 = 1.0F
        ' Blue
        myColorMatrix.Matrix33 = 1.0F
        ' alpha
        myColorMatrix.Matrix44 = 1.0F
        ' w

        ' Create an ImageAttributes object and set the color matrix.
        Dim imageAttr As New ImageAttributes
        imageAttr.SetColorMatrix(myColorMatrix)

        ' Draw the image using the color matrix.
        Dim rect As New Rectangle(100, 20, 200, 200)
        e.Graphics.DrawImage(myImage, rect, 0, 0, 200, 200, _
        GraphicsUnit.Pixel, imageAttr)
        ' Image
    End Sub
    'SetColorMatrixExample