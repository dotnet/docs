      private void WriteCenteredTextToRichTextBox()
      {
         // Clear all text from the RichTextBox;
         richTextBox1.Clear();
         // Set the foreground color of the text.
         richTextBox1.ForeColor = Color.Red;
         // Set the alignment of the text that follows.
         richTextBox1.SelectionAlignment = HorizontalAlignment.Center;
         // Set the font for the text.
         richTextBox1.SelectionFont = new Font("Lucinda Console", 12);
         // Set the text within the control.
         richTextBox1.SelectedText = "This text is centered using the SelectionAlignment property.\n";
      }