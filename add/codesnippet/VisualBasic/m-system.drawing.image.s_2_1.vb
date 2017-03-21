    Private Sub DemonstratePropertyItem(ByVal e As PaintEventArgs)

        ' Create two images.
        Dim image1 As Image = Image.FromFile("c:\FakePhoto1.jpg")
        Dim image2 As Image = Image.FromFile("c:\FakePhoto2.jpg")

        ' Get a PropertyItem from image1.
        Dim propItem As PropertyItem = image1.GetPropertyItem(20624)

        ' Change the ID of the PropertyItem.
        propItem.Id = 20625

        ' Set the PropertyItem for image2.
        image2.SetPropertyItem(propItem)

        ' Draw the image.
        e.Graphics.DrawImage(image2, 20.0F, 20.0F)
    End Sub