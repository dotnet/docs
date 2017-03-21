        public void Clone_Example(PaintEventArgs e)
        {
            // Create a Font object.
            Font myFont = new Font("Arial", 16);
                     
            // Create a copy of myFont.
            Font cloneFont = (Font)myFont.Clone();
                     
            // Use cloneFont to draw text to the screen.
            e.Graphics.DrawString("This is a cloned font", cloneFont,
                Brushes.Black, 0, 0);
        }