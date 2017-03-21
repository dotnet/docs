    private void DemonstratePropertyItem(PaintEventArgs e)
    {

        // Create two images.
        Image image1 = Image.FromFile("c:\\FakePhoto1.jpg");
        Image image2 = Image.FromFile("c:\\FakePhoto2.jpg");

        // Get a PropertyItem from image1.
        PropertyItem propItem = image1.GetPropertyItem(20624);

        // Change the ID of the PropertyItem.
        propItem.Id = 20625;

        // Set the PropertyItem for image2.
        image2.SetPropertyItem(propItem);

        // Draw the image.
        e.Graphics.DrawImage(image2, 20.0F, 20.0F);
    }