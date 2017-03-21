        public void FromArgb2(PaintEventArgs e)
        {
            Graphics     g = e.Graphics;
                     
            // Opaque colors (alpha value defaults to 255 -- max value).
            Color red = Color.FromArgb(255, 0, 0);
            Color green = Color.FromArgb(0, 255, 0);
            Color blue = Color.FromArgb(0, 0, 255);
                     
            // Solid brush initialized to red.
            SolidBrush  myBrush = new SolidBrush(red);
            int alpha;

            // x coordinate of first red rectangle
            int x = 50;         
            
            // y coordinate of first red rectangle
            int y = 50;         
                           
            // Fill rectangles with red, varying the alpha value from 25 to 250.
            for (alpha = 25; alpha <= 250; alpha += 25)
            {
                myBrush.Color = Color.FromArgb(alpha, red);
                g.FillRectangle(myBrush, x, y, 50, 100);
                g.FillRectangle(myBrush, x, y + 250, 50, 50);
                x += 50;
            }
            // x coordinate of first green rectangle.
            x = 50;             
            
            // y coordinate of first green rectangle.
            y += 50;            
                              
            // Fill rectangles with green, varying the alpha value from 25 to 250.
            for (alpha = 25; alpha <= 250; alpha += 25)
            {
                myBrush.Color = Color.FromArgb(alpha, green);
                g.FillRectangle(myBrush, x, y, 50, 150);
                x += 50;
            }
            // x coordinate of first blue rectangle.
            x = 50;             
            
            // y coordinate of first blue rectangle.
            y += 100;           
                     
            // Fill rectangles with blue, varying the alpha value from 25 to 250.
            for (alpha = 25; alpha <= 250; alpha += 25)
            {
                myBrush.Color = Color.FromArgb(alpha, blue);
                g.FillRectangle(myBrush, x, y, 50, 150);
                x += 50;
            }
        }