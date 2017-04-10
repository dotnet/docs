// <snippet1>
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsApplication3
{
	public class Form1 : Form
	{
		private ToolStrip toolStrip2;
		private ToolStrip toolStrip1;
		private ToolStripButton newToolStripButton;
		private ToolStripButton openToolStripButton;
		private ToolStripButton saveToolStripButton;
		private ToolStripButton printToolStripButton;
		private ToolStripSeparator toolStripSeparator;
		private ToolStripButton cutToolStripButton;
		private ToolStripButton copyToolStripButton;
		private ToolStripButton pasteToolStripButton;
		private ToolStripSeparator toolStripSeparator1;
		private ToolStripButton helpToolStripButton;
		private ToolStripButton toolStripButton1;
		private ToolStripButton toolStripButton2;
		private ToolStripContainer toolStripContainer1;
	
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
			this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
			this.toolStrip1 = new System.Windows.Forms.ToolStrip();
			this.newToolStripButton = new System.Windows.Forms.ToolStripButton();
			this.openToolStripButton = new System.Windows.Forms.ToolStripButton();
			this.saveToolStripButton = new System.Windows.Forms.ToolStripButton();
			this.printToolStripButton = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
			this.cutToolStripButton = new System.Windows.Forms.ToolStripButton();
			this.copyToolStripButton = new System.Windows.Forms.ToolStripButton();
			this.pasteToolStripButton = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.helpToolStripButton = new System.Windows.Forms.ToolStripButton();
			this.toolStrip2 = new System.Windows.Forms.ToolStrip();
			this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
			this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
			this.toolStripContainer1.LeftToolStripPanel.SuspendLayout();
			this.toolStripContainer1.TopToolStripPanel.SuspendLayout();
			this.toolStripContainer1.SuspendLayout();
			this.toolStrip1.SuspendLayout();
			this.toolStrip2.SuspendLayout();
			this.SuspendLayout();
			// 
			// toolStripContainer1
			// 
			this.toolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
			// 
			// LeftToolStripPanel
			// 
                        // <snippet2>
			this.toolStripContainer1.LeftToolStripPanel.Controls.Add(this.toolStrip2);
			this.toolStripContainer1.Location = new System.Drawing.Point(0, 0);
			this.toolStripContainer1.Name = "toolStripContainer1";
			this.toolStripContainer1.Size = new System.Drawing.Size(292, 273);
			this.toolStripContainer1.TabIndex = 0;
			this.toolStripContainer1.Text = "toolStripContainer1";
			// 
			// TopToolStripPanel
			// 
			this.toolStripContainer1.TopToolStripPanel.Controls.Add(this.toolStrip1);
			// </snippet2>
			// toolStrip1
			// 
			this.toolStrip1.Dock = System.Windows.Forms.DockStyle.None;
                        // <snippet3>
			this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] 
                        {
                        this.newToolStripButton,
                        this.openToolStripButton,
                        this.saveToolStripButton,
                        this.printToolStripButton,
                        this.toolStripSeparator,
                        this.cutToolStripButton,
                        this.copyToolStripButton,
                        this.pasteToolStripButton,
                        this.toolStripSeparator1,
                        this.helpToolStripButton});
                        // </snippet3>
			this.toolStrip1.Location = new System.Drawing.Point(0, 0);
			this.toolStrip1.Name = "toolStrip1";
			this.toolStrip1.TabIndex = 0;
			this.toolStrip1.Text = "toolStrip1";
			// 
			// newToolStripButton
			// 
			this.newToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("newToolStripButton.Image")));
			this.newToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.newToolStripButton.Name = "newToolStripButton";
			this.newToolStripButton.Text = "&New";
			// 
			// openToolStripButton
			// 
			this.openToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("openToolStripButton.Image")));
			this.openToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.openToolStripButton.Name = "openToolStripButton";
			this.openToolStripButton.Text = "&Open";
			// 
			// saveToolStripButton
			// 
			this.saveToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("saveToolStripButton.Image")));
			this.saveToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.saveToolStripButton.Name = "saveToolStripButton";
			this.saveToolStripButton.Text = "&Save";
			// 
			// printToolStripButton
			// 
			this.printToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("printToolStripButton.Image")));
			this.printToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.printToolStripButton.Name = "printToolStripButton";
			this.printToolStripButton.Text = "&Print";
			// 
			// toolStripSeparator
			// 
			this.toolStripSeparator.Name = "toolStripSeparator";
			// 
			// cutToolStripButton
			// 
			this.cutToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("cutToolStripButton.Image")));
			this.cutToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.cutToolStripButton.Name = "cutToolStripButton";
			this.cutToolStripButton.Text = "Cu&t";
			// 
			// copyToolStripButton
			// 
			this.copyToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("copyToolStripButton.Image")));
			this.copyToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.copyToolStripButton.Name = "copyToolStripButton";
			this.copyToolStripButton.Text = "&Copy";
			// 
			// pasteToolStripButton
			// 
			this.pasteToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("pasteToolStripButton.Image")));
			this.pasteToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.pasteToolStripButton.Name = "pasteToolStripButton";
			this.pasteToolStripButton.Text = "&Paste";
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			// 
			// helpToolStripButton
			// 
			this.helpToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("helpToolStripButton.Image")));
			this.helpToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.helpToolStripButton.Name = "helpToolStripButton";
			this.helpToolStripButton.Text = "&Help";
			// 
			// toolStrip2
			// 
			this.toolStrip2.Dock = System.Windows.Forms.DockStyle.None;
			this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1,
            this.toolStripButton2});
			this.toolStrip2.Location = new System.Drawing.Point(0, 0);
			this.toolStrip2.Name = "toolStrip2";
			this.toolStrip2.TabIndex = 0;
			this.toolStrip2.Text = "toolStrip2";
			// 
			// toolStripButton1
			// 
			this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.toolStripButton1.Name = "toolStripButton1";
			this.toolStripButton1.Text = "toolStripButton1";
			// 
			// toolStripButton2
			// 
			this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.toolStripButton2.Name = "toolStripButton2";
			this.toolStripButton2.Text = "toolStripButton2";
			// 
			// Form1
			// 
			this.ClientSize = new System.Drawing.Size(292, 273);
			this.Controls.Add(this.toolStripContainer1);
			this.Name = "Form1";
			this.toolStripContainer1.LeftToolStripPanel.ResumeLayout(false);
			this.toolStripContainer1.LeftToolStripPanel.PerformLayout();
			this.toolStripContainer1.TopToolStripPanel.ResumeLayout(false);
			this.toolStripContainer1.TopToolStripPanel.PerformLayout();
			this.toolStripContainer1.ResumeLayout(false);
			this.toolStripContainer1.PerformLayout();
			this.toolStrip1.ResumeLayout(false);
			this.toolStrip2.ResumeLayout(false);
			this.ResumeLayout(false);

		}
	}
}
// </snippet1>