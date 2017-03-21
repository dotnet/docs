    Public Sub SetRemapTableExample(ByVal e As PaintEventArgs)

        ' Create a filled, red image and save it to Circle2.jpg.
        Dim myBitmap As New Bitmap(50, 50)
        Dim g As Graphics = Graphics.FromImage(myBitmap)
        g.Clear(Color.White)
        g.FillEllipse(New SolidBrush(Color.Red), New Rectangle(0, 0, _
        50, 50))
        myBitmap.Save("Circle2.jpg")

        ' Create an Image object from the Circle2.jpg file, and draw

        ' it to the screen.
        Dim myImage As Image = Image.FromFile("Circle2.jpg")
        e.Graphics.DrawImage(myImage, 20, 20)

        ' Create a color map.
        Dim myColorMap(0) As ColorMap
        myColorMap(0) = New ColorMap
        myColorMap(0).OldColor = Color.Red
        myColorMap(0).NewColor = Color.Green

        ' Create an ImageAttributes object, and then pass the

        ' myColorMap object to the SetRemapTable method.
        Dim imageAttr As New ImageAttributes
        imageAttr.SetRemapTable(myColorMap)

        ' Draw the image with the remap table set.
        Dim rect As New Rectangle(150, 20, 50, 50)
        e.Graphics.DrawImage(myImage, rect, 0, 0, 50, 50, _
        GraphicsUnit.Pixel, imageAttr)
        ' Image
    End Sub