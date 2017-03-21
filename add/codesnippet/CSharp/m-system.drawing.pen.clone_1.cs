        public void Clone_Example(PaintEventArgs e)
        {
                     
            // Create a Pen object.
            Pen myPen = new Pen(Color.Black, 5);
                     
            // Clone myPen.
            Pen clonePen = (Pen)myPen.Clone();
                     
            // Draw a line with clonePen.
            e.Graphics.DrawLine(clonePen, 0, 0, 100, 100);
        }