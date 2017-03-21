    Public Sub SetNoOpExample(ByVal e As PaintEventArgs)

        ' Create an Image object from the file Camera.jpg.
        Dim myImage As Image = Image.FromFile("Camera.jpg")

        ' Create an ImageAttributes object, and set the gamma to 0.25.
        Dim imageAttr As New ImageAttributes
        imageAttr.SetGamma(0.25F)

        ' Draw the image with gamma set to 0.25.
        Dim rect1 As New Rectangle(20, 20, 200, 200)
        e.Graphics.DrawImage(myImage, rect1, 0, 0, 200, 200, _
        GraphicsUnit.Pixel, imageAttr)

        ' Call the ImageAttributes NoOp method.
        imageAttr.SetNoOp()

        ' Draw the image with gamma set to 0.25, but now NoOp is set,    
        ' so the uncorrected image will be shown.
        Dim rect2 As New Rectangle(250, 20, 200, 200)
        e.Graphics.DrawImage(myImage, rect2, 0, 0, 200, 200, _
        GraphicsUnit.Pixel, imageAttr)
        ' Image
    End Sub