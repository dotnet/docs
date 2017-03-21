        public void ResetTransform_Example(PaintEventArgs e)
        {
                     
            // Create a Pen object.
            Pen myPen = new Pen(Color.Black, 3);
                     
            // Scale the transformation matrix of myPen.
            myPen.ScaleTransform(2, 1);
                     
            // Draw a line with myPen.
            e.Graphics.DrawLine(myPen, 10, 0, 10, 200);
                     
            // Reset the transformation matrix of myPen to identity.
            myPen.ResetTransform();
                     
            // Draw a second line with myPen.
            e.Graphics.DrawLine(myPen, 100, 0, 100, 200);
        }