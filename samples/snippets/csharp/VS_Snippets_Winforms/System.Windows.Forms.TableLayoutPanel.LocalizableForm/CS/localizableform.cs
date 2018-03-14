//---------------------------------------------------------------------
//  This file is part of the Microsoft .NET Framework SDK Code Samples.
// 
//  Copyright (C) Microsoft Corporation.  All rights reserved.
// 
//This source code is intended only as a supplement to Microsoft
//Development Tools and/or on-line documentation.  See these other
//materials for detailed information regarding Microsoft code samples.
// 
//THIS CODE AND INFORMATION ARE PROVIDED AS IS WITHOUT WARRANTY OF ANY
//KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
//IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
//PARTICULAR PURPOSE.
//---------------------------------------------------------------------

// <snippet1>
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace TableLayoutPanelSample
{
    public class LocalizableForm : Form
    {
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private System.Windows.Forms.ListView listView1;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
		private System.Windows.Forms.Button button4;
		private System.Windows.Forms.Button button5;
		private System.Windows.Forms.Button button6;
		private System.Windows.Forms.Label label1;

		private System.ComponentModel.IContainer components = null;

        public LocalizableForm()
        {
            InitializeComponent();
        }

        private void AddText(object sender, EventArgs e)
        {
            ((Button)sender).Text += "x";
        }

		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		private void InitializeComponent()
		{
			System.Windows.Forms.ListViewGroup listViewGroup16 = new System.Windows.Forms.ListViewGroup("First Group", System.Windows.Forms.HorizontalAlignment.Left);
			System.Windows.Forms.ListViewGroup listViewGroup17 = new System.Windows.Forms.ListViewGroup("Second Group", System.Windows.Forms.HorizontalAlignment.Left);
			System.Windows.Forms.ListViewGroup listViewGroup18 = new System.Windows.Forms.ListViewGroup("Third Group", System.Windows.Forms.HorizontalAlignment.Left);
			System.Windows.Forms.ListViewItem listViewItem26 = new System.Windows.Forms.ListViewItem("Item 1");
			System.Windows.Forms.ListViewItem listViewItem27 = new System.Windows.Forms.ListViewItem("Item 2");
			System.Windows.Forms.ListViewItem listViewItem28 = new System.Windows.Forms.ListViewItem("Item 3");
			System.Windows.Forms.ListViewItem listViewItem29 = new System.Windows.Forms.ListViewItem("Item 4");
			System.Windows.Forms.ListViewItem listViewItem30 = new System.Windows.Forms.ListViewItem("Item 5");
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.listView1 = new System.Windows.Forms.ListView();
			this.panel1 = new System.Windows.Forms.Panel();
			this.button3 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.button1 = new System.Windows.Forms.Button();
			this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
			this.button4 = new System.Windows.Forms.Button();
			this.button5 = new System.Windows.Forms.Button();
			this.button6 = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.tableLayoutPanel1.SuspendLayout();
			this.panel1.SuspendLayout();
			this.tableLayoutPanel2.SuspendLayout();
			this.SuspendLayout();
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.ColumnCount = 2;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel1.Controls.Add(this.listView1, 1, 0);
			this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
			this.tableLayoutPanel1.Location = new System.Drawing.Point(2, 52);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 1;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(524, 270);
			this.tableLayoutPanel1.TabIndex = 1;
			// 
			// listView1
			// 
			this.listView1.Dock = System.Windows.Forms.DockStyle.Fill;
			listViewGroup16.Header = "First Group";
			listViewGroup16.Name = null;
			listViewGroup17.Header = "Second Group";
			listViewGroup17.Name = null;
			listViewGroup18.Header = "Third Group";
			listViewGroup18.Name = null;
			this.listView1.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] {
            listViewGroup16,
            listViewGroup17,
            listViewGroup18});
			//this.listView1.IsBackgroundImageTiled = false;
			listViewItem26.Group = listViewGroup16;
			listViewItem27.Group = listViewGroup16;
			listViewItem28.Group = listViewGroup17;
			listViewItem29.Group = listViewGroup17;
			listViewItem30.Group = listViewGroup18;
			this.listView1.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem26,
            listViewItem27,
            listViewItem28,
            listViewItem29,
            listViewItem30});
			this.listView1.Location = new System.Drawing.Point(90, 3);
			this.listView1.Name = "listView1";
			this.listView1.Size = new System.Drawing.Size(431, 264);
			this.listView1.TabIndex = 1;
			// 
			// panel1
			// 
			this.panel1.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.panel1.AutoSize = true;
			this.panel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.panel1.Controls.Add(this.button3);
			this.panel1.Controls.Add(this.button2);
			this.panel1.Controls.Add(this.button1);
			this.panel1.Location = new System.Drawing.Point(3, 3);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(81, 86);
			this.panel1.TabIndex = 2;
			// 
			// button3
			// 
			this.button3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.button3.AutoSize = true;
			this.button3.Location = new System.Drawing.Point(3, 60);
			this.button3.Name = "button3";
			this.button3.TabIndex = 2;
			this.button3.Text = "Add Text";
			this.button3.Click += new System.EventHandler(this.AddText);
			// 
			// button2
			// 
			this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.button2.AutoSize = true;
			this.button2.Location = new System.Drawing.Point(3, 31);
			this.button2.Name = "button2";
			this.button2.TabIndex = 1;
			this.button2.Text = "Add Text";
			this.button2.Click += new System.EventHandler(this.AddText);
			// 
			// button1
			// 
			this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.button1.AutoSize = true;
			this.button1.Location = new System.Drawing.Point(3, 2);
			this.button1.Name = "button1";
			this.button1.TabIndex = 0;
			this.button1.Text = "Add Text";
			this.button1.Click += new System.EventHandler(this.AddText);
			// 
			// tableLayoutPanel2
			// 
			this.tableLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.tableLayoutPanel2.AutoSize = true;
			this.tableLayoutPanel2.ColumnCount = 3;
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
			this.tableLayoutPanel2.Controls.Add(this.button4, 0, 0);
			this.tableLayoutPanel2.Controls.Add(this.button5, 1, 0);
			this.tableLayoutPanel2.Controls.Add(this.button6, 2, 0);
			this.tableLayoutPanel2.Location = new System.Drawing.Point(284, 328);
			this.tableLayoutPanel2.Name = "tableLayoutPanel2";
			this.tableLayoutPanel2.RowCount = 1;
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel2.Size = new System.Drawing.Size(243, 34);
			this.tableLayoutPanel2.TabIndex = 2;
			// 
			// button4
			// 
			this.button4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.button4.AutoSize = true;
			this.button4.Location = new System.Drawing.Point(3, 5);
			this.button4.Name = "button4";
			this.button4.TabIndex = 0;
			this.button4.Text = "Add Text";
			this.button4.Click += new System.EventHandler(this.AddText);
			// 
			// button5
			// 
			this.button5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.button5.AutoSize = true;
			this.button5.Location = new System.Drawing.Point(84, 5);
			this.button5.Name = "button5";
			this.button5.TabIndex = 1;
			this.button5.Text = "Add Text";
			this.button5.Click += new System.EventHandler(this.AddText);
			// 
			// button6
			// 
			this.button6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.button6.AutoSize = true;
			this.button6.Location = new System.Drawing.Point(165, 5);
			this.button6.Name = "button6";
			this.button6.TabIndex = 2;
			this.button6.Text = "Add Text";
			this.button6.Click += new System.EventHandler(this.AddText);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(8, 7);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(518, 40);
			this.label1.TabIndex = 3;
			this.label1.Text = "Click on any button to add text to the button. This simulates localizing strings," +
				" and provides a good demonstration of how the dialog will automatically adjust w" +
				"hen those longer strings are added to the UI.";
			// 
			// LocalizableForm
			// 
			this.ClientSize = new System.Drawing.Size(539, 374);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.tableLayoutPanel2);
			this.Controls.Add(this.tableLayoutPanel1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Name = "LocalizableForm";
			this.Text = "Localizable Dialog";
			this.tableLayoutPanel1.ResumeLayout(false);
			this.tableLayoutPanel1.PerformLayout();
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.tableLayoutPanel2.ResumeLayout(false);
			this.tableLayoutPanel2.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		[STAThread]
		static void Main()
		{
			Application.EnableVisualStyles();
			Application.Run(new LocalizableForm());
		}
    }
}
// </snippet1>