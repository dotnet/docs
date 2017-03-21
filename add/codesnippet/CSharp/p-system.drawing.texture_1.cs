    private void Button2_Click(System.Object sender, System.EventArgs e)
    {
        try
        {
            Bitmap image1 = (Bitmap) Image.FromFile(@"C:\Documents and Settings\" +
                @"All Users\Documents\My Music\music.bmp", true);

            TextureBrush texture = new TextureBrush(image1);
            texture.WrapMode = System.Drawing.Drawing2D.WrapMode.Tile;
            Graphics formGraphics = this.CreateGraphics();
            formGraphics.FillEllipse(texture, 
                new RectangleF(90.0F, 110.0F, 100, 100));
            formGraphics.Dispose();

        }
        catch(System.IO.FileNotFoundException)
        {
            MessageBox.Show("There was an error opening the bitmap." +
                "Please check the path.");
        }

    }