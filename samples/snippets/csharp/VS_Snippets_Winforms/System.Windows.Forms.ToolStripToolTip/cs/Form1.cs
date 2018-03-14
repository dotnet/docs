//<snippet1>
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsApplication7
{
	public class Form1 : Form
	{
		private ToolStripButton toolStripButton1;
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
			this.toolStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// toolStrip1
			// 
			this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1});
			this.toolStrip1.Location = new System.Drawing.Point(0, 0);
			this.toolStrip1.Name = "toolStrip1";
			this.toolStrip1.TabIndex = 0;
			this.toolStrip1.Text = "toolStrip1";
			// 
			// toolStripButton1
			// <snippet2>
			this.toolStripButton1.AutoToolTip = false;
			this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.toolStripButton1.Name = "toolStripButton1";
			this.toolStripButton1.Text = "Button1";
			this.toolStripButton1.ToolTipText = "ToolTip for Button1.";
			// </snippet2>
			// Form1
			// 
			this.ClientSize = new System.Drawing.Size(292, 273);
			this.Controls.Add(this.toolStrip1);
			this.Name = "Form1";
			this.toolStrip1.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}
	}
}
//</snippet1>