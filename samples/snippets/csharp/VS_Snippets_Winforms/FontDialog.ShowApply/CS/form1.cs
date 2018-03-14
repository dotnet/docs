using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace FontDialog_cs
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.FontDialog fontDialog1;
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
			this.fontDialog1 = new System.Windows.Forms.FontDialog();
			this.richTextBox1 = new System.Windows.Forms.RichTextBox();
			this.SuspendLayout();
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(32, 8);
			this.button1.Name = "button1";
			this.button1.TabIndex = 0;
			this.button1.Text = "button1";
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// fontDialog1
			// 
			this.fontDialog1.Apply += new System.EventHandler(this.fontDialog1_Apply);
			// 
			// richTextBox1
			// 
			this.richTextBox1.Location = new System.Drawing.Point(56, 72);
			this.richTextBox1.Name = "richTextBox1";
			this.richTextBox1.TabIndex = 1;
			this.richTextBox1.Text = "richTextBox1";
			// 
			// Form1
			// 
			this.ClientSize = new System.Drawing.Size(292, 273);
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

//<snippet1>

private void button1_Click(object sender, System.EventArgs e)
{
	// Sets the ShowApply property, then displays the dialog.

	fontDialog1.ShowApply = true;
	fontDialog1.ShowDialog();
}

private void fontDialog1_Apply(object sender, System.EventArgs e)
{
	// Applies the selected font to the selected text.
	richTextBox1.Font = fontDialog1.Font;
			
}
//</snippet1>
	}
}
