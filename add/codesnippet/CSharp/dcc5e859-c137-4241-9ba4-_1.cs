        private void IsVisibleExample(PaintEventArgs e)
        {
                     
            // Create a path and add an ellipse.
            GraphicsPath myPath = new GraphicsPath();
            myPath.AddEllipse(0, 0, 100, 100);
                     
            // Test the visibility of point (50, 50).
            bool visible = myPath.IsVisible(50, 50, e.Graphics);
                     
            // Show the result.
            MessageBox.Show(visible.ToString());
        }