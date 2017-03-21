    private void ShowOutputChannels(PaintEventArgs e)
    {
        //Create a bitmap from a file.
        Bitmap bmp1 = new Bitmap("c:\\fakePhoto.jpg");

        // Create a new bitmap from the original, resizing it for this example.
        Bitmap bmp2 = new Bitmap(bmp1, new Size(80, 80));

        bmp1.Dispose();

        // Create an ImageAttributes object.
        ImageAttributes imgAttributes = new ImageAttributes();

        // Draw the image unaltered.
        e.Graphics.DrawImage(bmp2, 10, 10);

        // Draw the image, showing the intensity of the cyan channel.
        imgAttributes.SetOutputChannel(ColorChannelFlag.ColorChannelC,
            System.Drawing.Imaging.ColorAdjustType.Bitmap);

        e.Graphics.DrawImage(bmp2, new Rectangle(100, 10, bmp2.Width, bmp2.Height),
            0, 0, bmp2.Width, bmp2.Height, GraphicsUnit.Pixel, imgAttributes);

        // Draw the image, showing the intensity of the magenta channel.
        imgAttributes.SetOutputChannel(ColorChannelFlag.ColorChannelM,
            ColorAdjustType.Bitmap);

        e.Graphics.DrawImage(bmp2, new Rectangle(10, 100, bmp2.Width, bmp2.Height),
            0, 0, bmp2.Width, bmp2.Height, GraphicsUnit.Pixel, imgAttributes);

        // Draw the image, showing the intensity of the yellow channel.
        imgAttributes.SetOutputChannel(ColorChannelFlag.ColorChannelY,
            ColorAdjustType.Bitmap);

        e.Graphics.DrawImage(bmp2, new Rectangle(100, 100, bmp2.Width, bmp2.Height), 0, 0,
            bmp2.Width, bmp2.Height, GraphicsUnit.Pixel, imgAttributes);

        // Draw the image, showing the intensity of the black channel.
        imgAttributes.SetOutputChannel(ColorChannelFlag.ColorChannelK,

            System.Drawing.Imaging.ColorAdjustType.Bitmap);
        e.Graphics.DrawImage(bmp2, new Rectangle(10, 190, bmp2.Width, bmp2.Height),
            0, 0, bmp2.Width, bmp2.Height, GraphicsUnit.Pixel, imgAttributes);

        //Dispose of the bitmap.
        bmp2.Dispose();

    }