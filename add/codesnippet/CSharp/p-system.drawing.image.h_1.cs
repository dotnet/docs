    Bitmap image1;

    private void Button1_Click(System.Object sender, System.EventArgs e)
    {

        try
        {
            // Retrieve the image.
            image1 = new Bitmap(@"C:\Documents and Settings\All Users\" 
                + @"Documents\My Music\music.bmp", true);

            int x, y;

            // Loop through the images pixels to reset color.
            for(x=0; x<image1.Width; x++)
            {
                for(y=0; y<image1.Height; y++)
                {
                    Color pixelColor = image1.GetPixel(x, y);
                    Color newColor = Color.FromArgb(pixelColor.R, 0, 0);
                    image1.SetPixel(x, y, newColor);
                }
            }

            // Set the PictureBox to display the image.
            PictureBox1.Image = image1;

            // Display the pixel format in Label1.
            Label1.Text = "Pixel format: "+image1.PixelFormat.ToString();

        }
        catch(ArgumentException)
        {
            MessageBox.Show("There was an error." +
                "Check the path to the image file.");
        }
    }