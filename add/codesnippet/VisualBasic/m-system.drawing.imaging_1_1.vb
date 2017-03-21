    Public Sub SetThresholdExample(ByVal e As PaintEventArgs)

        ' Open an Image file, and draw it to the screen.
        Dim myImage As Image = Image.FromFile("Camera.jpg")
        e.Graphics.DrawImage(myImage, 20, 20)

        ' Create an ImageAttributes object, and set its color threshold.
        Dim imageAttr As New ImageAttributes
        imageAttr.SetThreshold(0.7F)

        ' Draw the image with the colors bifurcated.
        Dim rect As New Rectangle(300, 20, 200, 200)
        e.Graphics.DrawImage(myImage, rect, 0, 0, 200, 200, _
        GraphicsUnit.Pixel, imageAttr)
    End Sub