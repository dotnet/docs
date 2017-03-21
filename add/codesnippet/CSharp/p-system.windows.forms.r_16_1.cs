		private void AddMyText(string textToAdd)
		{
			// Determine if the text to add is larger than the max length property.
			if (textToAdd.Length > richTextBox1.MaxLength)
				// Alert user text is too large.
				MessageBox.Show("The text is too large to addo to the RichTextBox");
			else
				// Add the text to be added to the control.
				richTextBox1.SelectedText = textToAdd;
		}