      private void Form1_Closing(object sender, System.ComponentModel.CancelEventArgs e)
      {
         // Determine if text has changed in the textbox by comparing to original text.
         if (textBox1.Text != strMyOriginalText)
         {
            // Display a MsgBox asking the user to save changes or abort.
            if(MessageBox.Show("Do you want to save changes to your text?", "My Application",
               MessageBoxButtons.YesNo) ==  DialogResult.Yes)
            {
               // Cancel the Closing event from closing the form.
               e.Cancel = true;
               // Call method to save file...
            }
         }
      }