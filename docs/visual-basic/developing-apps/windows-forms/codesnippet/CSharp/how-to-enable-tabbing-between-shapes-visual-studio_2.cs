        private void button1_PreviewKeyDown(object sender, System.Windows.Forms.PreviewKeyDownEventArgs e)
        {
            // Check for the Control and Tab keys.
            if (e.KeyCode == Keys.Tab & e.Modifiers == Keys.Control)
            // Select the first shape.
            {
                rectangleShape1.Select();
            }
        }