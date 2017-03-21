      private void AppendTextBox1Text()
      {
         // Determine if text is selected in textBox1.
         if(textBox1.SelectionLength == 0)
            // No selection made, return.
            return;
         
         // Determine if the text being appended to textBox2 exceeds the MaxLength property.
         if((textBox1.SelectedText.Length + textBox2.TextLength) > textBox2.MaxLength)
            MessageBox.Show("The text to paste in is larger than the maximum number of characters allowed");
         else
            // Append the text from textBox1 into textBox2.
            textBox2.AppendText(textBox1.SelectedText);
      }