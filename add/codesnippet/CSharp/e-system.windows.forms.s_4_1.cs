        private void HandleScroll(Object sender, ScrollEventArgs e)
        {
            //Create a graphics object and draw a portion of the image in the PictureBox.
            Graphics g = pictureBox1.CreateGraphics();

            int xWidth = pictureBox1.Width;
            int yHeight = pictureBox1.Height;

            int x;
            int y;

            if (e.ScrollOrientation == ScrollOrientation.HorizontalScroll)
            {
                x = e.NewValue;
                y = vScrollBar1.Value;
            }
            else //e.ScrollOrientation == ScrollOrientation.VerticalScroll
            {
                y = e.NewValue;
                x = hScrollBar1.Value;
            }

            g.DrawImage(pictureBox1.Image,
              new Rectangle(0, 0, xWidth, yHeight),  //where to draw the image
              new Rectangle(x, y, xWidth, yHeight),  //the portion of the image to draw
              GraphicsUnit.Pixel);

            pictureBox1.Update();
        }