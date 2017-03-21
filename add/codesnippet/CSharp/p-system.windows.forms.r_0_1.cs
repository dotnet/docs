      private void ProtectMySelectedText()
      {
         // Determine if the selected text in the control contains the word "RichTextBox".
         if(richTextBox1.SelectedText != "RichTextBox")
         {
            // Search for the word RichTextBox in the control.
            if(richTextBox1.Find("RichTextBox",RichTextBoxFinds.WholeWord)== -1)
            {
               //Alert the user that the word was not foun and return.
               MessageBox.Show("The text \"RichTextBox\" was not found!");
               return;
            }
         }
         // Protect the selected text in the control from being altered.
         richTextBox1.SelectionProtected = true;
      }