using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace RichTextBoxSelectionProtectedEx
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
      internal System.Windows.Forms.Button button1;
      internal System.Windows.Forms.RichTextBox richTextBox1;
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
         this.richTextBox1 = new System.Windows.Forms.RichTextBox();
         this.SuspendLayout();
         // 
         // button1
         // 
         this.button1.Location = new System.Drawing.Point(336, 96);
         this.button1.Name = "button1";
         this.button1.TabIndex = 5;
         this.button1.Text = "button1";
         this.button1.Click += new System.EventHandler(this.button1_Click);
         // 
         // richTextBox1
         // 
         this.richTextBox1.Location = new System.Drawing.Point(16, 48);
         this.richTextBox1.Name = "richTextBox1";
         this.richTextBox1.Size = new System.Drawing.Size(296, 168);
         this.richTextBox1.TabIndex = 4;
         this.richTextBox1.Text = "richTextBox1";
         // 
         // Form1
         // 
         this.ClientSize = new System.Drawing.Size(424, 254);
         this.Controls.AddRange(new System.Windows.Forms.Control[] {
                                                                      this.button1,
                                                                      this.richTextBox1});
         this.Name = "Form1";
         this.Text = "Form1";
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

      private void button1_Click(object sender, System.EventArgs e)
      {
         richTextBox1.Clear();
         richTextBox1.AppendText("This text is being added to the RichTextBox control to protect");
         ProtectMySelectedText();
      }

      //<Snippet1>
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
      //</Snippet1>
	}
}
