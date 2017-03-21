        private void MultiplyTransformExample(PaintEventArgs e)
        {
                     
            // Create a LinearGradientBrush.
            Rectangle myRect = new Rectangle(20, 20, 200, 100);
            LinearGradientBrush myLGBrush = new LinearGradientBrush(
                myRect, Color.Blue, Color.Red,  0.0f, true);
                
            // Draw an ellipse to the screen using the LinearGradientBrush.
            e.Graphics.FillEllipse(myLGBrush, myRect);
                     
            // Transform the LinearGradientBrush.
            Point[] transformArray = { new Point(20, 150),
                 new Point(400,150), new Point(20, 200) };
       
            Matrix myMatrix = new Matrix(myRect, transformArray);
            myLGBrush.MultiplyTransform(
                myMatrix,
                MatrixOrder.Prepend);
                     
            // Draw a second ellipse to the screen using
            // the transformed brush.
            e.Graphics.FillEllipse(myLGBrush, 20, 150, 380, 50);
        }