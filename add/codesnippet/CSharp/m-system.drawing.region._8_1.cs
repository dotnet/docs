        public void TransformExample(PaintEventArgs e)
        {
                     
            // Create the first rectangle and draw it to the screen in blue.
            Rectangle regionRect = new Rectangle(100, 50, 100, 100);
            e.Graphics.DrawRectangle(Pens.Blue, regionRect);
                     
            // Create a region using the first rectangle.
            Region myRegion = new Region(regionRect);
                     
            // Create a transform matrix and set it to have a 45 degree
                     
            // rotation.
            Matrix transformMatrix = new Matrix();
            transformMatrix.RotateAt(45, new Point(100, 50));
                     
            // Apply the transform to the region.
            myRegion.Transform(transformMatrix);
                     
            // Fill the transformed region with red and draw it to the screen
                     
            // in red.
            SolidBrush myBrush = new SolidBrush(Color.Red);
            e.Graphics.FillRegion(myBrush, myRegion);
        }