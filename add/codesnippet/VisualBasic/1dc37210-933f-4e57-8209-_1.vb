    Public Sub SetWrapModeExample(ByVal e As PaintEventArgs)

        ' Create a filled, red circle, and save it to Circle3.jpg.
        Dim myBitmap As New Bitmap(50, 50)
        Dim g As Graphics = Graphics.FromImage(myBitmap)
        g.Clear(Color.White)
        g.FillEllipse(New SolidBrush(Color.Red), New Rectangle(0, 0, _
        25, 25))
        myBitmap.Save("Circle3.jpg")

        ' Create an Image object from the Circle3.jpg file, and draw

        ' it to the screen.
        Dim myImage As Image = Image.FromFile("Circle3.jpg")
        e.Graphics.DrawImage(myImage, 20, 20)

        ' Set the wrap mode.
        Dim imageAttr As New ImageAttributes
        imageAttr.SetWrapMode(WrapMode.Tile)

        ' Create a TextureBrush.
        Dim brushRect As New Rectangle(0, 0, 25, 25)
        Dim myTBrush As New TextureBrush(myImage, brushRect, imageAttr)

        ' Draw to the screen a rectangle filled with red circles.
        e.Graphics.FillRectangle(myTBrush, 100, 20, 200, 200)
    End Sub