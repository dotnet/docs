    Public Sub SetGammaExample(ByVal e As PaintEventArgs)

        ' Create an Image object from the file Camera.jpg, and draw

        ' it to screen.
        Dim myImage As Image = Image.FromFile("Camera.jpg")
        e.Graphics.DrawImage(myImage, 20, 20)

        ' Create an ImageAttributes object and set the gamma to 2.2.
        Dim imageAttr As New System.Drawing.Imaging.ImageAttributes
        imageAttr.SetGamma(2.2F)

        ' Draw the image with gamma set to 2.2.
        Dim rect As New Rectangle(250, 20, 200, 200)
        e.Graphics.DrawImage(myImage, rect, 0, 0, 200, 200, _
        GraphicsUnit.Pixel, imageAttr)
        ' Image
    End Sub