        private void textBox1_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            // Determine whether the key entered is the F1 key. If it is, display Help.
            if(e.KeyCode == Keys.F1 && (e.Alt || e.Control || e.Shift))
            {
                // Display a pop-up Help topic to assist the user.
                Help.ShowPopup(textBox1, "Enter your name.", new Point(textBox1.Bottom, textBox1.Right));
            }
            else if(e.KeyCode == Keys.F2 && e.Modifiers == Keys.Alt)
            {
                // Display a pop-up Help topic to provide additional assistance to the user.
                Help.ShowPopup(textBox1, "Enter your first name followed by your last name. Middle name is optional.",
                    new Point(textBox1.Top, this.textBox1.Left));
            }
        }