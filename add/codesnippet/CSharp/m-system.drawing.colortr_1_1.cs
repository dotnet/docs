        public void ToHtml_Example(PaintEventArgs e)
        {
            // Create an instance of a Color structure.
            Color myColor = Color.Red;
                     
            // Translate myColor to an HTML color.
            string htmlColor = ColorTranslator.ToHtml(myColor);
                     
            // Show a message box with the value of htmlColor.
            MessageBox.Show(htmlColor);
        }