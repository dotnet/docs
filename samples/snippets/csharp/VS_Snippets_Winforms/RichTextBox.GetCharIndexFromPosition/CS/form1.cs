using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace RTBGetIndexFromPositionEx
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
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
			this.richTextBox1 = new System.Windows.Forms.RichTextBox();
			this.SuspendLayout();
			// 
			// richTextBox1
			// 
			this.richTextBox1.Location = new System.Drawing.Point(16, 16);
			this.richTextBox1.Name = "richTextBox1";
			this.richTextBox1.Size = new System.Drawing.Size(408, 232);
			this.richTextBox1.TabIndex = 0;
			this.richTextBox1.Text = "There once was a brown man from Nantucket...";
			this.richTextBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.richTextBox1_MouseDown);
			// 
			// Form1
			// 
			this.ClientSize = new System.Drawing.Size(440, 270);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
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

		//<Snippet1>
		private void richTextBox1_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			// Declare the string to search for in the control.
			string searchString = "brown";

			// Determine whether the user clicks the left mouse button and whether it is a double click.
			if (e.Clicks == 1 && e.Button == MouseButtons.Left)
			{
				// Obtain the character index where the user clicks on the control.
				int positionToSearch = richTextBox1.GetCharIndexFromPosition(new Point(e.X, e.Y));
				// Search for the search string text within the control from the point the user clicked.
				int textLocation = richTextBox1.Find(searchString, positionToSearch, RichTextBoxFinds.None);

				// If the search string is found (value greater than -1), display the index the string was found at.
				if (textLocation >= 0)
					MessageBox.Show("The search string was found at character index " + textLocation.ToString() + ".");
				else
					// Display a message box alerting the user that the text was not found.
					MessageBox.Show("The search string was not found within the text of the control.");
			}
		}
		//</Snippet1>
	}
}
