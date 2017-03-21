        private void SetSigmaBellShapeExample(PaintEventArgs e)
        {
                     
            // Create a LinearGradientBrush.
            Rectangle myRect = new Rectangle(20, 20, 200, 100);
            LinearGradientBrush myLGBrush = new LinearGradientBrush(
                myRect, Color.Blue, Color.Red,  0.0f, true);
                     
            // Draw an ellipse to the screen using the LinearGradientBrush.
            e.Graphics.FillEllipse(myLGBrush, myRect);
                     
            // Create a bell-shaped brush with the peak at the
                     
            // center of the drawing area.
            myLGBrush.SetSigmaBellShape(.5f, 1.0f);
                     
            // Use the bell- shaped brush to draw a second
            // ellipse.
            myRect.Y = 150;
            e.Graphics.FillEllipse(myLGBrush, myRect);
        }