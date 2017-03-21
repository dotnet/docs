      private void MyListView_AfterLabelEdit(object sender, System.Windows.Forms.LabelEditEventArgs e)
      {
       
         // Determine if label is changed by checking for null.
         if (e.Label == null)
            return;

         // ASCIIEncoding is used to determine if a number character has been entered.
         ASCIIEncoding AE = new ASCIIEncoding();
         // Convert the new label to a character array.
         char[] temp = e.Label.ToCharArray();

         // Check each character in the new label to determine if it is a number.
         for(int x=0; x < temp.Length; x++)
         {
            // Encode the character from the character array to its ASCII code.
            byte[] bc = AE.GetBytes(temp[x].ToString());
         
            // Determine if the ASCII code is within the valid range of numerical values.
            if(bc[0] > 47 && bc[0] < 58)
            {
               // Cancel the event and return the lable to its original state.
               e.CancelEdit = true;
               // Display a MessageBox alerting the user that numbers are not allowed.
               MessageBox.Show ("The text for the item cannot contain numerical values.");
               // Break out of the loop and exit.
               return;
            }
         }
      }