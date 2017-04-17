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
      private System.Windows.Forms.TextBox currencyTextBox;
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
         this.currencyTextBox = new System.Windows.Forms.TextBox();
         this.SuspendLayout();
         // 
         // currencyTextBox
         // 
         this.currencyTextBox.Location = new System.Drawing.Point(8, 8);
         this.currencyTextBox.Name = "currencyTextBox";
         this.currencyTextBox.Size = new System.Drawing.Size(104, 20);
         this.currencyTextBox.TabIndex = 0;
         this.currencyTextBox.Text = "";
         this.currencyTextBox.TextChanged += new System.EventHandler(this.currencyTextBox_TextChanged);
         // 
         // Form1
         // 
         this.ClientSize = new System.Drawing.Size(194, 103);
         this.Controls.AddRange(new System.Windows.Forms.Control[] {
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

// <snippet1>
private void currencyTextBox_TextChanged(object sender, EventArgs e)
{
   try
   {
      // Convert the text to a Double and determine if it is a negative number.
      if(double.Parse(currencyTextBox.Text) < 0)
      {
         // If the number is negative, display it in Red.
         currencyTextBox.ForeColor = Color.Red;
      }
      else
      {
         // If the number is not negative, display it in Black.
         currencyTextBox.ForeColor = Color.Black;
      }
   }
   catch
   {
      // If there is an error, display the text using the system colors.
      currencyTextBox.ForeColor = SystemColors.ControlText;
   }
}
// </snippet1>

	}
}
