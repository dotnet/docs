// <snippet1>
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace MdiFormCS
{
    // This code example demonstrates an MDI form 
    // that supports menu merging and moveable 
    // ToolStrip controls
    public class Form1 : Form
    {
        private MenuStrip menuStrip1;
        private ToolStripMenuItem toolStripMenuItem1;
        private ToolStripMenuItem newToolStripMenuItem;
        private ToolStripPanel toolStripPanel1;
        private ToolStrip toolStrip1;
        private ToolStripPanel toolStripPanel2;
        private ToolStrip toolStrip2;
        private ToolStripPanel toolStripPanel3;
        private ToolStrip toolStrip3;
        private ToolStripPanel toolStripPanel4;
        private ToolStrip toolStrip4;

        private System.ComponentModel.IContainer components = null;

        public Form1()
        {
            InitializeComponent();
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        // <snippet2>
        // This method creates a new ChildForm instance 
        // and attaches it to the MDI parent form.
        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChildForm f = new ChildForm();
            f.MdiParent = this;
            f.Text = "Form - " + this.MdiChildren.Length.ToString();
            f.Show();
        }
        // </snippet2>

        #region Windows Form Designer generated code
        
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripPanel1 = new System.Windows.Forms.ToolStripPanel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripPanel2 = new System.Windows.Forms.ToolStripPanel();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.toolStripPanel3 = new System.Windows.Forms.ToolStripPanel();
            this.toolStrip3 = new System.Windows.Forms.ToolStrip();
            this.toolStripPanel4 = new System.Windows.Forms.ToolStripPanel();
            this.toolStrip4 = new System.Windows.Forms.ToolStrip();
            this.menuStrip1.SuspendLayout();
            this.toolStripPanel1.SuspendLayout();
            this.toolStripPanel2.SuspendLayout();
            this.toolStripPanel3.SuspendLayout();
            this.toolStripPanel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.MdiWindowListItem = this.toolStripMenuItem1;
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(292, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(57, 20);
            this.toolStripMenuItem1.Text = "Window";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(106, 22);
            this.newToolStripMenuItem.Text = "New";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.newToolStripMenuItem_Click);
            // 
            // toolStripPanel1
            // 
            this.toolStripPanel1.Controls.Add(this.toolStrip1);
            this.toolStripPanel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.toolStripPanel1.Location = new System.Drawing.Point(0, 49);
            this.toolStripPanel1.Name = "toolStripPanel1";
            this.toolStripPanel1.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.toolStripPanel1.RowMargin = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.toolStripPanel1.Size = new System.Drawing.Size(26, 199);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip1.Location = new System.Drawing.Point(0, 3);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(26, 109);
            this.toolStrip1.TabIndex = 0;
            // 
            // toolStripPanel2
            // 
            this.toolStripPanel2.Controls.Add(this.toolStrip2);
            this.toolStripPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.toolStripPanel2.Location = new System.Drawing.Point(0, 24);
            this.toolStripPanel2.Name = "toolStripPanel2";
            this.toolStripPanel2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.toolStripPanel2.RowMargin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.toolStripPanel2.Size = new System.Drawing.Size(292, 25);
            // 
            // toolStrip2
            // 
            this.toolStrip2.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip2.Location = new System.Drawing.Point(3, 0);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(109, 25);
            this.toolStrip2.TabIndex = 0;
            // 
            // toolStripPanel3
            // 
            this.toolStripPanel3.Controls.Add(this.toolStrip3);
            this.toolStripPanel3.Dock = System.Windows.Forms.DockStyle.Right;
            this.toolStripPanel3.Location = new System.Drawing.Point(266, 49);
            this.toolStripPanel3.Name = "toolStripPanel3";
            this.toolStripPanel3.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.toolStripPanel3.RowMargin = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.toolStripPanel3.Size = new System.Drawing.Size(26, 199);
            // 
            // toolStrip3
            // 
            this.toolStrip3.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip3.Location = new System.Drawing.Point(0, 3);
            this.toolStrip3.Name = "toolStrip3";
            this.toolStrip3.Size = new System.Drawing.Size(26, 109);
            this.toolStrip3.TabIndex = 0;
            // 
            // toolStripPanel4
            // 
            this.toolStripPanel4.Controls.Add(this.toolStrip4);
            this.toolStripPanel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStripPanel4.Location = new System.Drawing.Point(0, 248);
            this.toolStripPanel4.Name = "toolStripPanel4";
            this.toolStripPanel4.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.toolStripPanel4.RowMargin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.toolStripPanel4.Size = new System.Drawing.Size(292, 25);
            // 
            // toolStrip4
            // 
            this.toolStrip4.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip4.Location = new System.Drawing.Point(3, 0);
            this.toolStrip4.Name = "toolStrip4";
            this.toolStrip4.Size = new System.Drawing.Size(109, 25);
            this.toolStrip4.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 273);
            this.Controls.Add(this.toolStripPanel3);
            this.Controls.Add(this.toolStripPanel1);
            this.Controls.Add(this.toolStripPanel2);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.toolStripPanel4);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.toolStripPanel1.ResumeLayout(false);
            this.toolStripPanel1.PerformLayout();
            this.toolStripPanel2.ResumeLayout(false);
            this.toolStripPanel2.PerformLayout();
            this.toolStripPanel3.ResumeLayout(false);
            this.toolStripPanel3.PerformLayout();
            this.toolStripPanel4.ResumeLayout(false);
            this.toolStripPanel4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
    }

    public class ChildForm : Form
    {
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.ComponentModel.IContainer components = null;

        public ChildForm()
        {
            InitializeComponent();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code
        
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(292, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(90, 20);
            this.toolStripMenuItem1.Text = "ChildMenuItem";
            // 
            // ChildForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 273);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "ChildForm";
            this.Text = "ChildForm";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
    }

    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.Run(new Form1());
        }
    }
}
// </snippet1>