        private void TranslateTransformExample(PaintEventArgs e)
        {
                     
            // Create a LinearGradientBrush.
            Rectangle myRect = new Rectangle(20, 20, 200, 100);
            LinearGradientBrush myLGBrush = new LinearGradientBrush(
                myRect, Color.Blue, Color.Red,  0.0f, true);
                     
            // Draw a rectangle to the screen using the LinearGradientBrush.
            e.Graphics.FillRectangle(myLGBrush, myRect);
                     
            // Rotate the LinearGradientBrush.
            myLGBrush.RotateTransform(90.0f);
                     
            // Scale the gradient for the height of the rectangle.
            myLGBrush.ScaleTransform(0.5f, 1.0f);
                     
            // Draw to the screen, the rotated and scaled gradient.
            e.Graphics.FillRectangle(myLGBrush, 20, 150, 200, 100);
                     
            // Rejustify the brush to start at the top edge of the
            // rectangle.
            myLGBrush.TranslateTransform(-20.0f, 0.0f);
                     
            // Draw a third rectangle to the screen using the translated
            // brush.
            e.Graphics.FillRectangle(myLGBrush, 20, 300, 200, 100);
        }