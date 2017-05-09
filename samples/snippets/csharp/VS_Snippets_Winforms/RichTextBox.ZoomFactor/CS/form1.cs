using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace RTBZoomEx
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
			this.button1.Location = new System.Drawing.Point(256, 224);
			this.button1.Name = "button1";
			this.button1.TabIndex = 0;
			this.button1.Text = "button1";
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// richTextBox1
			// 
			this.richTextBox1.Location = new System.Drawing.Point(48, 32);
			this.richTextBox1.Name = "richTextBox1";
			this.richTextBox1.Size = new System.Drawing.Size(192, 208);
			this.richTextBox1.TabIndex = 1;
			this.richTextBox1.Text = "richTextBox1";
			// 
			// Form1
			// 
			this.ClientSize = new System.Drawing.Size(360, 310);
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

		private void button1_Click(object sender, System.EventArgs e)
		{
			ZoomMyRichTextBox();
		}

		//<Snippet1>
		private void ZoomMyRichTextBox()
		{
			// Enable users to select entire word when double clicked.
			richTextBox1.AutoWordSelection = true;
			// Clear contents of control.
			richTextBox1.Clear();
			// Set the right margin to restrict horizontal text.
			richTextBox1.RightMargin = 2;
			// Set the text for the control.
			richTextBox1.SelectedText = "Alpha Bravo Charlie Delta Echo Foxtrot";
			// Zoom by 2 points.
			richTextBox1.ZoomFactor = 2.0f;
		}
		//</Snippet1>
	}
}
