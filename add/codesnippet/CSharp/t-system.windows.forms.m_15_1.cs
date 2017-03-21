		private void richTextBox1_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			// Determine which mouse button is clicked.
			if(e.Button == MouseButtons.Left)
			{
				// Obtain the character at which the mouse cursor was clicked at.
				char tempChar = richTextBox1.GetCharFromPosition(new Point(e.X, e.Y));
				// Determine whether the character is an empty space.
				if (tempChar.ToString() != " ")
					// Display the character in a message box.
					MessageBox.Show("The character at the specified position is " + tempChar + ".");

			}
		}