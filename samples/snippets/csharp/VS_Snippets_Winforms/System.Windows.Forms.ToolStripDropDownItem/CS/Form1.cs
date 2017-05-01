// <snippet1>
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace ToolStripDropDownItemCS
{
    public class Form1 : Form
    {
        private ToolStrip toolStrip1;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel toolStripStatusLabel1;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem menuItem1ToolStripMenuItem;
        private ToolStripMenuItem menuItem2ToolStripMenuItem;
        private ToolStripMenuItem subItemToolStripMenuItem;
        private ToolStripMenuItem subItem2ToolStripMenuItem;
        private Button showButton;
        private Button hideButton;
        private System.ComponentModel.IContainer components = null;

        public Form1()
        {
            InitializeComponent();
            this.InitializeToolStripDropDownItems();
        }

        // <snippet2>
        // This utility method creates and initializes three 
        // ToolStripDropDownItem controls and adds them 
        // to the form's ToolStrip control.
        private void InitializeToolStripDropDownItems()
        {
            ToolStripDropDownButton b = new ToolStripDropDownButton("DropDownButton");
            b.DropDown = this.contextMenuStrip1;
            b.DropDownClosed += new EventHandler(toolStripDropDownItem_DropDownClosed);
            b.DropDownItemClicked += new ToolStripItemClickedEventHandler(toolStripDropDownItem_DropDownItemClicked);
            b.DropDownOpened += new EventHandler(toolStripDropDownItem_DropDownOpened);

            ToolStripMenuItem m = new ToolStripMenuItem("MenuItem");
            m.DropDown = this.contextMenuStrip1;
            m.DropDownClosed += new EventHandler(toolStripDropDownItem_DropDownClosed);
            m.DropDownItemClicked += new ToolStripItemClickedEventHandler(toolStripDropDownItem_DropDownItemClicked);
            m.DropDownOpened += new EventHandler(toolStripDropDownItem_DropDownOpened);

            ToolStripSplitButton sb = new ToolStripSplitButton("SplitButton");
            sb.DropDown = this.contextMenuStrip1;
            sb.DropDownClosed += new EventHandler(toolStripDropDownItem_DropDownClosed);
            sb.DropDownItemClicked += new ToolStripItemClickedEventHandler(toolStripDropDownItem_DropDownItemClicked);
            sb.DropDownOpened += new EventHandler(toolStripDropDownItem_DropDownOpened);

            this.toolStrip1.Items.AddRange(new ToolStripItem[] { b, m, sb });
        }
        // </snippet2>

        // <snippet3>
        // This method handles the DropDownOpened event from a 
        // ToolStripDropDownItem. It displays the value of the 
        // item's Text property in the form's StatusStrip control.
        void toolStripDropDownItem_DropDownOpened(object sender, EventArgs e)
        {
            ToolStripDropDownItem item = sender as ToolStripDropDownItem;

            string msg = String.Format("Item opened: {0}", item.Text);
            this.toolStripStatusLabel1.Text = msg;
        }
        // </snippet3>

        // <snippet4>
        // This method handles the DropDownItemClicked event from a 
        // ToolStripDropDownItem. It displays the value of the clicked
        // item's Text property in the form's StatusStrip control.
        void toolStripDropDownItem_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            string msg = String.Format("Item clicked: {0}", e.ClickedItem.Text);
            this.toolStripStatusLabel1.Text = msg;
        }
        // </snippet4>

        // <snippet5>
        // This method handles the DropDownClosed event from a 
        // ToolStripDropDownItem. It displays the value of the 
        // item's Text property in the form's StatusStrip control.
        void toolStripDropDownItem_DropDownClosed(object sender, EventArgs e)
        {
            ToolStripDropDownItem item = sender as ToolStripDropDownItem;

            string msg = String.Format("Item closed: {0}", item.Text);
            this.toolStripStatusLabel1.Text = msg;
        }
        // </snippet5>

        // <snippet6>
        // This method shows the drop-down for the first item
        // in the form's ToolStrip.
        private void showButton_Click(object sender, EventArgs e)
        {
            ToolStripDropDownItem item = this.toolStrip1.Items[0] as ToolStripDropDownItem;

            if (item.HasDropDownItems)
            {
                item.ShowDropDown();
            }
        }
        // </snippet6>

        // <snippet7>
        // This method hides the drop-down for the first item
        // in the form's ToolStrip.
        private void hideButton_Click(object sender, EventArgs e)
        {
            ToolStripDropDownItem item = this.toolStrip1.Items[0] as ToolStripDropDownItem;

            item.HideDropDown();
        }
        // </snippet7>

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
            this.components = new System.ComponentModel.Container();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuItem1ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItem2ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.subItemToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.subItem2ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showButton = new System.Windows.Forms.Button();
            this.hideButton = new System.Windows.Forms.Button();
            this.statusStrip1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(292, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 251);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(292, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(38, 17);
            this.toolStripStatusLabel1.Text = "Ready";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItem1ToolStripMenuItem,
            this.menuItem2ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.contextMenuStrip1.Size = new System.Drawing.Size(146, 48);
            // 
            // menuItem1ToolStripMenuItem
            // 
            this.menuItem1ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.subItemToolStripMenuItem});
            this.menuItem1ToolStripMenuItem.Name = "menuItem1ToolStripMenuItem";
            this.menuItem1ToolStripMenuItem.Size = new System.Drawing.Size(145, 22);
            this.menuItem1ToolStripMenuItem.Text = "Menu Item1";
            // 
            // menuItem2ToolStripMenuItem
            // 
            this.menuItem2ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.subItem2ToolStripMenuItem});
            this.menuItem2ToolStripMenuItem.Name = "menuItem2ToolStripMenuItem";
            this.menuItem2ToolStripMenuItem.Size = new System.Drawing.Size(145, 22);
            this.menuItem2ToolStripMenuItem.Text = "Menu Item 2";
            // 
            // subItemToolStripMenuItem
            // 
            this.subItemToolStripMenuItem.Name = "subItemToolStripMenuItem";
            this.subItemToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.subItemToolStripMenuItem.Text = "Sub Item";
            // 
            // subItem2ToolStripMenuItem
            // 
            this.subItem2ToolStripMenuItem.Name = "subItem2ToolStripMenuItem";
            this.subItem2ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.subItem2ToolStripMenuItem.Text = "Sub Item2";
            // 
            // showButton
            // 
            this.showButton.Location = new System.Drawing.Point(12, 180);
            this.showButton.Name = "showButton";
            this.showButton.Size = new System.Drawing.Size(75, 23);
            this.showButton.TabIndex = 2;
            this.showButton.Text = "Show";
            this.showButton.UseVisualStyleBackColor = true;
            this.showButton.Click += new System.EventHandler(this.showButton_Click);
            // 
            // hideButton
            // 
            this.hideButton.Location = new System.Drawing.Point(12, 209);
            this.hideButton.Name = "hideButton";
            this.hideButton.Size = new System.Drawing.Size(75, 23);
            this.hideButton.TabIndex = 3;
            this.hideButton.Text = "Hide";
            this.hideButton.UseVisualStyleBackColor = true;
            this.hideButton.Click += new System.EventHandler(this.hideButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 273);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.hideButton);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.showButton);
            this.Name = "Form1";
            this.Text = "Form1";
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
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
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
// </snippet1>