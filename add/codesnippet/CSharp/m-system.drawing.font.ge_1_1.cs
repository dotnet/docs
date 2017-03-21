        public void GetHeight_Example(PaintEventArgs e)
        {
                     
            // Create a Font object.
            Font myFont = new Font("Arial", 16);
                     
            //Draw text to the screen with myFont.
            e.Graphics.DrawString("This is the first line",myFont,
                Brushes.Black, new PointF(0, 0));
                     
            //Get the height of myFont.
            float height = myFont.GetHeight(e.Graphics);
                     
            //Draw text immediately below the first line of text.
            e.Graphics.DrawString(
                "This is the second line",
                myFont,
                Brushes.Black,
                new PointF(0, height));
        }