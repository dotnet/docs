using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.Button button1;
                private System.Windows.Forms.Button button2;
		private System.Windows.Forms.ErrorProvider errorProvider1;



		private void InitializeComponent()
		{
                        //Set up the controls on the form.
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.button1 = new System.Windows.Forms.Button();
                        this.button2 = new System.Windows.Forms.Button();
			this.errorProvider1 = new System.Windows.Forms.ErrorProvider();
			this.textBox1.Location = new System.Drawing.Point(16, 16);
			this.textBox1.Size = new System.Drawing.Size(216, 20);
			this.textBox1.TabIndex = 0;
			this.textBox1.Text = "textBox1";
			this.textBox1.Validating += new System.ComponentModel.CancelEventHandler(this.textBox1_Validating);
			this.textBox1.Validated += new System.EventHandler(this.textBox1_Validated);
			this.button1.Location = new System.Drawing.Point(208, 240);
			this.button1.TabIndex = 2;
			this.button1.Text = "button1";

                        //Here we create the non-validating button.
			this.button2.Location = new System.Drawing.Point(108, 240);
			this.button2.TabIndex = 1;
			this.button2.Text = "Non-Validating";
			this.errorProvider1.DataMember = null;
			this.ClientSize = new System.Drawing.Size(292, 273);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {this.textBox1,this.button1,this.button2});
			this.Text = "Form1";

		}

		[STAThread]
		static void Main() 
		{
			Application.Run(new Form1());
		}
//<Snippet2>
public Form1()
{
    InitializeComponent();
    //Set button2 to be non-validating.
    this.button2.CausesValidation = false;
}


//  <Snippet1>
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
// </Snippet1>
// </Snippet2>
}

