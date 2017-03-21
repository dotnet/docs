      private void ModifySelectedText()
      {
         // Determine if text is selected in the control.
         if (richTextBox1.SelectionLength > 0)
         {
            // Set the color of the selected text in the control.
            richTextBox1.SelectionColor = Color.Red;
            // Set the font of the selected text to bold and underlined.
            richTextBox1.SelectionFont = new Font("Arial",10,FontStyle.Bold | FontStyle.Underline);
            // Protect the selected text from modification.
            richTextBox1.SelectionProtected = true;
         }
      }