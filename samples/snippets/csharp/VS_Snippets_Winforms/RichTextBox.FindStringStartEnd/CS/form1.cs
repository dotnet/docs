using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace RTBFindStringStartEndEx
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.RichTextBox richTextBox1;
		private System.Windows.Forms.Button button1;
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
			this.richTextBox1 = new System.Windows.Forms.RichTextBox();
			this.button1 = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// richTextBox1
			// 
			this.richTextBox1.Location = new System.Drawing.Point(16, 16);
			this.richTextBox1.Name = "richTextBox1";
			this.richTextBox1.Size = new System.Drawing.Size(256, 160);
			this.richTextBox1.TabIndex = 0;
			this.richTextBox1.Text = "Alpha Bravo Charlie Delta Echo Foxtrot Golf";
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(200, 184);
			this.button1.Name = "button1";
			this.button1.TabIndex = 1;
			this.button1.Text = "button1";
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// Form1
			// 
			this.ClientSize = new System.Drawing.Size(280, 214);
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
			MessageBox.Show(FindMyText("Golf", 44, -1).ToString());	
		}

		//<Snippet1>
		public int FindMyText(string searchText, int searchStart, int searchEnd)
		{
			// Initialize the return value to false by default.
			int returnValue = -1;

			// Ensure that a search string and a valid starting point are specified.
			if (searchText.Length > 0 && searchStart >= 0) 
			{
				// Ensure that a valid ending value is provided.
				if (searchEnd > searchStart || searchEnd == -1)
				{	
					// Obtain the location of the search string in richTextBox1.
					int indexToText = richTextBox1.Find(searchText, searchStart, searchEnd, RichTextBoxFinds.MatchCase);
					// Determine whether the text was found in richTextBox1.
					if(indexToText >= 0)
					{
						// Return the index to the specified search text.
						returnValue = indexToText;
					}
				}
			}

			return returnValue;
		}
		//</Snippet1>
	}
}
