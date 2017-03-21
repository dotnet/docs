    private void ConstructFromResourceSaveAsGif(PaintEventArgs e)
    {

        // Construct a bitmap from the button image resource.
        Bitmap bmp1 = new Bitmap(typeof(Button), "Button.bmp");

        // Save the image as a GIF.
        bmp1.Save("c:\\button.gif", System.Drawing.Imaging.ImageFormat.Gif);

        // Construct a new image from the GIF file.
        Bitmap bmp2 = new Bitmap("c:\\button.gif");

        // Draw the two images.
        e.Graphics.DrawImage(bmp1, new Point(10, 10));
        e.Graphics.DrawImage(bmp2, new Point(10, 40));

        // Dispose of the image files.
        bmp1.Dispose();
        bmp2.Dispose();
    }