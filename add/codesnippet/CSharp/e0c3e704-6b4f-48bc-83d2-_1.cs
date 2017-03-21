        private void ScaleTransformExample(PaintEventArgs e)
        {
                     
            // Create a LinearGradientBrush.
            Rectangle myRect = new Rectangle(20, 20, 200, 100);
            LinearGradientBrush myLGBrush = new LinearGradientBrush(
                myRect, Color.Blue, Color.Red,  0.0f, true);
                     
            // Draw an ellipse to the screen using the LinearGradientBrush.
            e.Graphics.FillEllipse(myLGBrush, myRect);
                     
            // Scale the LinearGradientBrush.
            myLGBrush.ScaleTransform(2.0f, 1.0f, MatrixOrder.Prepend);
           
            // Rejustify the brush to start at the left edge of the ellipse.
            myLGBrush.TranslateTransform(-20.0f, 0.0f);
                     
            // Draw a second ellipse to the screen using
            // the transformed brush.
            e.Graphics.FillEllipse(myLGBrush, 20, 150, 200, 100);
        }