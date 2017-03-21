		private void WriteIndentedTextToRichTextBox()
		{
			// Clear all text from the RichTextBox;
			richTextBox1.Clear();
		    // Specify a 20 pixel right indent in all paragraphs.
      	    richTextBox1.SelectionRightIndent = 20;
			// Set the font for the text.
			richTextBox1.Font = new Font("Lucinda Console", 12);
			// Set the text within the control.
			richTextBox1.SelectedText = "All text is indented 20 pixels from the right edge of the RichTextBox.";
			richTextBox1.SelectedText = "You can use this property with the SelectionIndent property to provide right and left margins.";
			richTextBox1.SelectedText = "After this paragraph the indentation will end.\n\n";
            // Remove all right indentation.
            richTextBox1.SelectionRightIndent = 0;
			richTextBox1.SelectedText = "This paragraph has no right indentation. All text should flow as normal.";
		}