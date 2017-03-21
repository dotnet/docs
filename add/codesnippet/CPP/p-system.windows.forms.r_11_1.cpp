private:
   void WriteOffsetTextToRichTextBox()
   {
      // Clear all text from the RichTextBox.
      richTextBox1->Clear();

      // Set the font for the text.
      richTextBox1->SelectionFont = gcnew System::Drawing::Font( "Lucinda Console",12 );

      // Set the foreground color of the text.
      richTextBox1->SelectionColor = Color::Purple;

      // Set the baseline text.
      richTextBox1->SelectedText = "10";

      // Set the CharOffset to display superscript text.
      richTextBox1->SelectionCharOffset = 10;

      // Set the superscripted text. 
      richTextBox1->SelectedText = "2";

      // Reset the CharOffset to display text at the baseline.
      richTextBox1->SelectionCharOffset = 0;
      richTextBox1->AppendText( "\n\n" );

      // Change the forecolor of the next text selection.
      richTextBox1->SelectionColor = Color::Blue;

      // Set the baseline text.
      richTextBox1->SelectedText = "77";

      // Set the CharOffset to display subscript text.
      richTextBox1->SelectionCharOffset = -10;

      // Set the subscripted text.  
      richTextBox1->SelectedText = "3";

      // Reset the CharOffset to display text at the baseline.
      richTextBox1->SelectionCharOffset = 0;
   }