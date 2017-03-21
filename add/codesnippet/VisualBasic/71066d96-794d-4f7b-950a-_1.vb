    Public Sub SetColorKeyExample(ByVal e As PaintEventArgs)

        ' Open an Image file, and draw it to the screen.
        Dim myImage As Image = Image.FromFile("Circle.bmp")
        e.Graphics.DrawImage(myImage, 20, 20)

        ' Create an ImageAttributes object and set the color key.
        Dim lowerColor As Color = Color.FromArgb(245, 0, 0)
        Dim upperColor As Color = Color.FromArgb(255, 0, 0)
        Dim imageAttr As New ImageAttributes
        imageAttr.SetColorKey(lowerColor, upperColor, _
        ColorAdjustType.Default)

        ' Draw the image with the color key set.
        Dim rect As New Rectangle(150, 20, 100, 100)
        e.Graphics.DrawImage(myImage, rect, 0, 0, 100, 100, _
        GraphicsUnit.Pixel, imageAttr)
        ' Image
    End Sub