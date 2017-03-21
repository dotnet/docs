        public void ToString_Example(PaintEventArgs e)
        {
            // Create a Font object.
            Font myFont = new Font("Arial", 16);
                     
            // Get a string that represents myFont.
            string fontString = myFont.ToString();
                     
            // Display a message box with fontString.
            MessageBox.Show(fontString);
        }