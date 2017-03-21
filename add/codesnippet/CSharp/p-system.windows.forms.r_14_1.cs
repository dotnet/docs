      private void WriteTextToRichTextBox()
      {
         // Clear all text from the RichTextBox;
         richTextBox1.Clear();
         // Set the font for the opening text to a larger Arial font;
         richTextBox1.SelectionFont = new Font("Arial", 16);
         // Assign the introduction text to the RichTextBox control.
         richTextBox1.SelectedText = "The following is a list of bulleted items:" + "\n";
         // Set the Font for the first item to a smaller size Arial font.
         richTextBox1.SelectionFont = new Font("Arial", 12);
         // Specify that the following items are to be added to a bulleted list.
         richTextBox1.SelectionBullet = true;
         // Set the color of the item text.
         richTextBox1.SelectionColor = Color.Red;
         // Assign the text to the bulleted item.
         richTextBox1.SelectedText = "Apples" + "\n";
         // Apply same font since font settings do not carry to next line.
         richTextBox1.SelectionFont = new Font("Arial", 12);
         richTextBox1.SelectionColor = Color.Orange;
         richTextBox1.SelectedText = "Oranges" + "\n";
         richTextBox1.SelectionFont = new Font("Arial", 12);
         richTextBox1.SelectionColor = Color.Purple;
         richTextBox1.SelectedText = "Grapes" + "\n";
         // End the bulleted list.
         richTextBox1.SelectionBullet = false;
         // Specify the font size and string for text displayed below bulleted list.
         richTextBox1.SelectionFont = new Font("Arial", 16);
         richTextBox1.SelectedText = "Bulleted Text Complete!";
      }