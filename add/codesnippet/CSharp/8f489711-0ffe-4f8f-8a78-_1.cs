		private void richTextBox1_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			// Declare the string to search for in the control.
			string searchString = "brown";

			// Determine whether the user clicks the left mouse button and whether it is a double click.
			if (e.Clicks == 1 && e.Button == MouseButtons.Left)
			{
				// Obtain the character index where the user clicks on the control.
				int positionToSearch = richTextBox1.GetCharIndexFromPosition(new Point(e.X, e.Y));
				// Search for the search string text within the control from the point the user clicked.
				int textLocation = richTextBox1.Find(searchString, positionToSearch, RichTextBoxFinds.None);

				// If the search string is found (value greater than -1), display the index the string was found at.
				if (textLocation >= 0)
					MessageBox.Show("The search string was found at character index " + textLocation.ToString() + ".");
				else
					// Display a message box alerting the user that the text was not found.
					MessageBox.Show("The search string was not found within the text of the control.");
			}
		}