public Form1()
{
    InitializeComponent();
    //Set button2 to be non-validating.
    this.button2.CausesValidation = false;
}


private void textBox1_Validating(object sender, 
 				System.ComponentModel.CancelEventArgs e)
{
   string errorMsg;
   if(!ValidEmailAddress(textBox1.Text, out errorMsg))
   {
      // Cancel the event and select the text to be corrected by the user.
      e.Cancel = true;
      textBox1.Select(0, textBox1.Text.Length);

      // Set the ErrorProvider error with the text to display. 
      this.errorProvider1.SetError(textBox1, errorMsg);
   }
}

private void textBox1_Validated(object sender, System.EventArgs e)
{
   // If all conditions have been met, clear the ErrorProvider of errors.
   errorProvider1.SetError(textBox1, "");
}
public bool ValidEmailAddress(string emailAddress, out string errorMessage)
{
   // Confirm that the e-mail address string is not empty.
   if(emailAddress.Length == 0)
   {
      errorMessage = "e-mail address is required.";
         return false;
   }

   // Confirm that there is an "@" and a "." in the e-mail address, and in the correct order.
   if(emailAddress.IndexOf("@") > -1)
   {
      if(emailAddress.IndexOf(".", emailAddress.IndexOf("@") ) > emailAddress.IndexOf("@") )
      {
         errorMessage = "";
         return true;
      }
   }
   
   errorMessage = "e-mail address must be valid e-mail address format.\n" +
      "For example 'someone@example.com' ";
      return false;
}