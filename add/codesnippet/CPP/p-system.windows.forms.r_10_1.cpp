private:
   void WriteIndentedTextToRichTextBox()
   {
      // Clear all text from the RichTextBox;
      richTextBox1->Clear();

      // Specify a 20 pixel hanging indent in all paragraphs.
      richTextBox1->SelectionHangingIndent = 20;

      // Set the font for the text.
      richTextBox1->Font = gcnew System::Drawing::Font( "Lucinda Console",12 );

      // Set the text within the control.
      richTextBox1->SelectedText = "This text contains a hanging indent. The first sentence of the paragraph is spaced normally.";
      richTextBox1->SelectedText = "All subsequent lines of text are indented based on the value of SelectionHangingIndent.";
      richTextBox1->SelectedText = "After this paragraph the indent is returned to normal spacing.\n";
      richTextBox1->SelectedText = "Since this is a new paragraph the indent is also applied to this paragraph.";
      richTextBox1->SelectedText = "All subsequent lines of text are indented based on the value of SelectionHangingIndent.";
   }