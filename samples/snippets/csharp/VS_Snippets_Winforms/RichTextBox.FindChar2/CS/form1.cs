using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace RTBFindChar2Ex
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.RichTextBox richTextBox1;
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
			this.button1.Location = new System.Drawing.Point(200, 224);
			this.button1.Name = "button1";
			this.button1.TabIndex = 0;
			this.button1.Text = "button1";
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// richTextBox1
			// 
			this.richTextBox1.Location = new System.Drawing.Point(16, 16);
			this.richTextBox1.Name = "richTextBox1";
			this.richTextBox1.Size = new System.Drawing.Size(248, 192);
			this.richTextBox1.TabIndex = 1;
			this.richTextBox1.Text = "Alpha Bravo Charlie Delta Echo";
			// 
			// Form1
			// 
			this.ClientSize = new System.Drawing.Size(292, 266);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.richTextBox1,
																		  this.button1});
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

		// <Snippet1>
		private void button1_Click(object sender, System.EventArgs e)
		{
			MessageBox.Show(FindMyText(new char[]{'B','r','a','v','o'}, 5).ToString());
		}

		public int FindMyText(char[] text, int start)
		{
			// Initialize the return value to false by default.
			int returnValue = -1;

			// Ensure that a valid char array has been specified and a valid start point.
			if (text.Length > 0 && start >= 0) 
			{
				// Obtain the location of the first character found in the control
				// that matches any of the characters in the char array.
				int indexToText = richTextBox1.Find(text, start);
				// Determine whether any of the chars are found in richTextBox1.
				if(indexToText >= 0)
				{
					// Return the location of the character.
					returnValue = indexToText;
				}
			}

			return returnValue;
		}
		//</Snippet1>
	}
}
