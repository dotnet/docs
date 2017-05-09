using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace FormClosingEx
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
      private string strMyOriginalText = "";
      private System.Windows.Forms.Button button1;
      private System.Windows.Forms.TextBox textBox1;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public Form1()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
         

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

      

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
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
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
         this.button1 = new System.Windows.Forms.Button();
         this.textBox1 = new System.Windows.Forms.TextBox();
         this.SuspendLayout();
         // 
         // button1
         // 
         this.button1.Location = new System.Drawing.Point(200, 64);
         this.button1.Name = "button1";
         this.button1.TabIndex = 0;
         this.button1.Text = "button1";
         // 
         // textBox1
         // 
         this.textBox1.Location = new System.Drawing.Point(48, 64);
         this.textBox1.Name = "textBox1";
         this.textBox1.TabIndex = 1;
         this.textBox1.Text = "textBox1";
         // 
         // Form1
         // 
         this.ClientSize = new System.Drawing.Size(292, 266);
         this.Controls.AddRange(new System.Windows.Forms.Control[] {
                                                                      this.textBox1,
                                                                      this.button1});
         this.Name = "Form1";
         this.Text = "Form1";
         this.Closing += new System.ComponentModel.CancelEventHandler(this.Form1_Closing);
         this.ResumeLayout(false);

      }
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new Form1());
		}

      //<Snippet1>
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
      //</Snippet1>
	}
}
