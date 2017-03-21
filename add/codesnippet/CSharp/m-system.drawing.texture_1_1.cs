        public void MultiplyTransform_Example1(PaintEventArgs e)
        {
                     
            // Create a TextureBrush object.
            TextureBrush tBrush = new TextureBrush(new Bitmap("texture.jpg"));
                     
            // Create a transformation matrix.
            Matrix translateMatrix = new Matrix();
            translateMatrix.Translate(50, 0);
                     
            // Multiply the transformation matrix of tBrush by translateMatrix.
            tBrush.MultiplyTransform(translateMatrix, MatrixOrder.Prepend);
                     
            // Fill a rectangle with tBrush.
            e.Graphics.FillRectangle(tBrush, 0, 110, 100, 100);
        }