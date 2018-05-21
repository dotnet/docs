        private void shapes_PreviewKeyDown(Shape sender, System.Windows.Forms.PreviewKeyDownEventArgs e)
        {
            Shape sh;
            // Check for the Control and Tab keys.
            if (e.KeyCode == Keys.Tab && e.Modifiers == Keys.Control)
            // Find the next shape in the order.
            {
                sh = shapeContainer1.GetNextShape(sender, true);
                // Select the next shape.
                shapeContainer1.SelectNextShape(sender, false, true);
            }
        }