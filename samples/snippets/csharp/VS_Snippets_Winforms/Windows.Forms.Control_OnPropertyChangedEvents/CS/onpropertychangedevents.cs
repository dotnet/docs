using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace PropChanged
{
   public class Form1 : System.Windows.Forms.Form
   {
      private MyTextBox currencyTextBox;
      private System.Windows.Forms.Button button1;
      private System.ComponentModel.Container components = null;

      public Form1()
      {
         InitializeComponent();

      }

      protected override void Dispose( bool disposing )
      {
         if( disposing )
         {
            if (components != null) 
            {
               components.Dispose();
            }
         }
         base.Dispose( disposing );
      }

		#region Windows Form Designer generated code
      private void InitializeComponent()
      {
         this.currencyTextBox = new PropChanged.MyTextBox();
         this.button1 = new System.Windows.Forms.Button();
         this.SuspendLayout();
         // 
         // currencyTextBox
         // 
         this.currencyTextBox.Location = new System.Drawing.Point(8, 8);
         this.currencyTextBox.Name = "currencyTextBox";
         this.currencyTextBox.Size = new System.Drawing.Size(104, 20);
         this.currencyTextBox.TabIndex = 0;
         this.currencyTextBox.Text = "";
         // 
         // button1
         // 
         this.button1.Location = new System.Drawing.Point(64, 48);
         this.button1.Name = "button1";
         this.button1.TabIndex = 1;
         this.button1.Text = "button1";
         // 
         // Form1
         // 
         this.ClientSize = new System.Drawing.Size(194, 103);
         this.Controls.AddRange(new System.Windows.Forms.Control[] {
                                                                      this.button1,
                                                                      this.currencyTextBox});
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
         this.Name = "Form1";
         this.Text = "Form1";
         this.ResumeLayout(false);

      }
		#endregion

      [STAThread]
      static void Main() 
      {
         Application.Run(new Form1());
      }
   }

   public class MyTextBox : TextBox
   {

// <snippet1>
protected override void OnTextChanged(System.EventArgs e)
{
   try
   {
      // Convert the text to a Double and determine
      // if it is a negative number.
      if(double.Parse(this.Text) < 0)
      {
         // If the number is negative, display it in Red.
         this.ForeColor = Color.Red;
      }
      else
      {
         // If the number is not negative, display it in Black.
         this.ForeColor = Color.Black;
      }
   }
   catch
   {
      // If there is an error, display the 
      // text using the system colors.
      this.ForeColor = SystemColors.ControlText;
   }
   
   base.OnTextChanged(e);
}
// </snippet1>

   }


}