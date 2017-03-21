		private void WriteIndentedTextToRichTextBox()
		{
			// Clear all text from the RichTextBox;
			richTextBox1.Clear();
			// Specify a 20 pixel indent in all paragraphs.
			richTextBox1.SelectionIndent = 20;
			// Set the font for the text.
			richTextBox1.Font = new Font("Lucinda Console", 12);
			// Set the text within the control.
			richTextBox1.SelectedText = "All text is indented 20 pixels from the left edge of the RichTextBox.";
			richTextBox1.SelectedText = "You can use this property to provide proper indentation such as when writing a letter.";
			richTextBox1.SelectedText = "After this paragraph the indent is returned to normal spacing.\n\n";
			richTextBox1.SelectionIndent = 0;
			richTextBox1.SelectedText = "No indenation is applied to this paragraph. All text in the paragraph flows from each control edge.";
		}