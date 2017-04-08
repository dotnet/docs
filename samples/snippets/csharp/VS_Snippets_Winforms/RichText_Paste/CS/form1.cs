using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace RichText_CanPaste_CS
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

			pasteMyBitmap("c:\\NoImage.bmp");
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

		//<snippet1>
private bool pasteMyBitmap(string fileName)
{

	// Open an bitmap from file and copy it to the clipboard.
	Bitmap myBitmap = new Bitmap(fileName);
			
	// Copy the bitmap to the clipboard.
	Clipboard.SetDataObject(myBitmap);

	// Get the format for the object type.
	DataFormats.Format myFormat = DataFormats.GetFormat(DataFormats.Bitmap);

	// After verifying that the data can be pasted, paste it.
	if(richTextBox1.CanPaste(myFormat))
	{
		richTextBox1.Paste(myFormat);
		return true;
	}
	else
	{
		MessageBox.Show("The data format that you attempted to paste is not supported by this control.");
		return false;
	}
}

//</snippet1>

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
			this.richTextBox1.Location = new System.Drawing.Point(40, 136);
			this.richTextBox1.Name = "richTextBox1";
			this.richTextBox1.TabIndex = 0;
			this.richTextBox1.Text = "richTextBox1";
			// 
			// Form1
			// 
			this.ClientSize = new System.Drawing.Size(292, 273);
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
	}
}
