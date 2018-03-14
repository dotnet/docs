//<snippet1>
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsApplication11
{
	public class Form1 : Form
	{
		private ToolStripButton toolStripButton1;
		private ToolStripButton toolStripButton2;
		private ToolStrip toolStrip1;
	
		public Form1()
		{
			InitializeComponent();
		}
		[STAThread]
		static void Main()
		{
			Application.EnableVisualStyles();
			Application.Run(new Form1());
		}

		private void InitializeComponent()
		{
			this.toolStrip1 = new System.Windows.Forms.ToolStrip();
			this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
			this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
			this.toolStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// toolStrip1
			// 
			this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1,
            this.toolStripButton2});
			this.toolStrip1.Location = new System.Drawing.Point(0, 0);
			this.toolStrip1.Name = "toolStrip1";
			this.toolStrip1.TabIndex = 0;
			this.toolStrip1.Text = "toolStrip1";
			// 
			// toolStripButton1
			//
                        // <snippet2> 
			this.toolStripButton1.Image = Bitmap.FromFile("c:\\NewItem.bmp");
			this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.ImageAndText;
			this.toolStripButton1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.toolStripButton1.Name = "toolStripButton1";
			this.toolStripButton1.Text = "&New";
			this.toolStripButton1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
                        // </snippet2>
			// 
			// toolStripButton2
			// 
			this.toolStripButton2.Image = Bitmap.FromFile("c:\\OpenItem.bmp");
			this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.ImageAndText;
			this.toolStripButton2.Name = "toolStripButton2";
			this.toolStripButton2.Text = "&Open";
			this.toolStripButton2.Click += new System.EventHandler(this.toolStripButton2_Click);
			// 
			// Form1
			// 
			this.ClientSize = new System.Drawing.Size(292, 273);
			this.Controls.Add(this.toolStrip1);
			this.Name = "Form1";
			this.toolStrip1.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		private void toolStripButton1_Click(object sender, EventArgs e)
		{
			MessageBox.Show("You have mail.");
		}

		private void toolStripButton2_Click(object sender, EventArgs e)
		{
			// Add the response to the Click event here.
		}
	}
}
//</snippet1>