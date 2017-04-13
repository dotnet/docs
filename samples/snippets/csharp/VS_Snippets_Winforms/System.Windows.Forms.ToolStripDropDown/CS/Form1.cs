// <snippet1>
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace ToolStripDropDownCS
{
    public class Form1 : Form
    {
        private System.ComponentModel.IContainer components = null;
        private CheckBox autoCloseCheckBox;
        private Button closeButton;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel toolStripStatusLabel1;
        private RadioButton radioButton1;
        private RadioButton radioButton2;
        private RadioButton radioButton3;
        private RadioButton radioButton4;
        private RadioButton radioButton5;
        private RadioButton radioButton6;
        private RadioButton radioButton7;
        private GroupBox groupBox1;
        private Button showButton;
        private Button showAtPointButton;
        private ToolStripStatusLabel toolStripStatusLabel2;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem item1ToolStripMenuItem;
        private ToolStripMenuItem subItem1ToolStripMenuItem;
        private Button button1;
        private ToolStripMenuItem subItem2ToolStripMenuItem;
        private ToolStripMenuItem doneToolStripMenuItem;
        private Button button2;

        ToolStripDropDownDirection dropDownDirection;

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
        // This method calls the ToolStripDropDown control's Show 
        // method to display the ContextMenuStrip relative to the
        // owning control.
        private void button1_MouseUp(object sender, MouseEventArgs e)
        {
            Control c = sender as Control;
            if (e.Button == MouseButtons.Right)
            {
                this.contextMenuStrip1.Show(c, e.Location, this.dropDownDirection);
            }
        }
        // </snippet2>

        // <snippet3>
        // This method calls the ToolStripDropDown control's Show 
        // method to display the ContextMenuStrip in its 
        // default location.
        private void showButton_Click(object sender, EventArgs e)
        {
            this.contextMenuStrip1.Show();
        }
        // </snippet3>

        // <snippet4>
        // This method calls the ToolStripDropDown control's Show 
        // method to display the ContextMenuStrip relative to the
        // origin of the form. 
        private void showRelativeButton_Click(object sender, EventArgs e)
        {
            this.contextMenuStrip1.Show(this.Location, this.dropDownDirection);
        }
        // </snippet4>

        // <snippet5>
        // This method calls the ToolStripDropDown control's Show 
        // method to display the ContextMenuStrip at a fixed point.
        private void showAtPointButton_Click(object sender, EventArgs e)
        {
            this.contextMenuStrip1.Show(23, 55);
        }
        // </snippet5>

        // <snippet6>
        // This method handles the Closing event. The ToolStripDropDown
        // control is not allowed to close unless the Done menu item
        // is clicked or the Close method is called explicitly.
        // The Done menu item is enabled only after both of the other
        // menu items have been selected.
        private void contextMenuStrip_Closing(
            object sender, 
            ToolStripDropDownClosingEventArgs e)
        {
            if (e.CloseReason != ToolStripDropDownCloseReason.CloseCalled)
            {
                if (subItem1ToolStripMenuItem.Checked &&
                    subItem2ToolStripMenuItem.Checked &&
                    doneToolStripMenuItem.Enabled)
                {
                    // Reset the state of menu items.
                    subItem1ToolStripMenuItem.Checked = false;
                    subItem2ToolStripMenuItem.Checked = false;
                    doneToolStripMenuItem.Enabled = false;

                    // Allow the ToolStripDropDown to close.
                    // Don't cancel the Close operation.
                    e.Cancel = false;
                }
                else
                {
                    // Cancel the Close operation to keep the menu open.
                    e.Cancel = true;
                    this.toolStripStatusLabel1.Text = "Close canceled";
                }
            }
        }
        // </snippet6>

        // <snippet7>
        // This method handles the ToolStripDropDown control's 
        // Closed event. It displays the CloseReason in the 
        // ToolStripStatusLabel control.
        void contextMenuStrip_Closed(object sender, ToolStripDropDownClosedEventArgs e)
        {
            string msg = String.Format(
                "DropDown closed - CloseReason: {0}", 
                e.CloseReason.ToString());

            this.toolStripStatusLabel1.Text = msg;
        }
        // </snippet7>

        // <snippet8>
        // This method explicitly closes the ToolStripDropDown control
        // and specifies the reason for closing as CloseCalled.
        private void closeButton_Click(object sender, EventArgs e)
        {
            this.contextMenuStrip1.Close(ToolStripDropDownCloseReason.CloseCalled);
        }
        // </snippet8>

        // <snippet9>
        // This method toggles the value of the ToolStripDropDown 
        // control's AutoClose property.
        private void autoCloseCheckBox_CheckedChanged(object sender, EventArgs e)
        {   
            this.contextMenuStrip1.AutoClose ^= true;
        }
        // </snippet9>

        // <snippet10>
        // This method toggles the value of a subitem's Checked property.
        private void subItemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem item = sender as ToolStripMenuItem;

            item.Checked ^= true;

            this.doneToolStripMenuItem.Enabled = 
                subItem1ToolStripMenuItem.Checked && subItem2ToolStripMenuItem.Checked;
        }
        // </snippet10>

        // <snippet11>
        // The following methods handle the CheckChanged event 
        // for all the radio buttons. Each method calls a utility
        // method to set the ToolStripDropDownDirection appropriately.

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            this.HandleRadioButton(sender, ToolStripDropDownDirection.AboveLeft);
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            this.HandleRadioButton(sender, ToolStripDropDownDirection.AboveRight);
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            this.HandleRadioButton(sender, ToolStripDropDownDirection.BelowLeft);
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            this.HandleRadioButton(sender, ToolStripDropDownDirection.BelowRight);
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            this.HandleRadioButton(sender, ToolStripDropDownDirection.Default);
        }

        private void radioButton6_CheckedChanged(object sender, EventArgs e)
        {
            this.HandleRadioButton(sender, ToolStripDropDownDirection.Left);
        }

        private void radioButton7_CheckedChanged(object sender, EventArgs e)
        {
            this.HandleRadioButton(sender, ToolStripDropDownDirection.Right);
        }

        // This utility method sets the DefaultDropDownDirection property.
        private void HandleRadioButton(object sender, ToolStripDropDownDirection direction)
        {
            RadioButton rb = sender as RadioButton;

            if (rb != null)
            {
                if (rb.Checked)
                {
                    this.dropDownDirection = direction;
                    this.contextMenuStrip1.DefaultDropDownDirection = direction;
                }
            }
        }
        // </snippet11>


        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.autoCloseCheckBox = new System.Windows.Forms.CheckBox();
            this.closeButton = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.radioButton4 = new System.Windows.Forms.RadioButton();
            this.radioButton5 = new System.Windows.Forms.RadioButton();
            this.radioButton6 = new System.Windows.Forms.RadioButton();
            this.radioButton7 = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.showButton = new System.Windows.Forms.Button();
            this.showAtPointButton = new System.Windows.Forms.Button();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.item1ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.subItem1ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.subItem2ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.doneToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.statusStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // autoCloseCheckBox
            // 
            this.autoCloseCheckBox.AutoSize = true;
            this.autoCloseCheckBox.Checked = true;
            this.autoCloseCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.autoCloseCheckBox.Location = new System.Drawing.Point(13, 288);
            this.autoCloseCheckBox.Name = "autoCloseCheckBox";
            this.autoCloseCheckBox.Size = new System.Drawing.Size(74, 17);
            this.autoCloseCheckBox.TabIndex = 1;
            this.autoCloseCheckBox.Text = "AutoClose";
            this.autoCloseCheckBox.UseVisualStyleBackColor = true;
            this.autoCloseCheckBox.CheckedChanged += new System.EventHandler(this.autoCloseCheckBox_CheckedChanged);
            // 
            // closeButton
            // 
            this.closeButton.Location = new System.Drawing.Point(12, 259);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(95, 23);
            this.closeButton.TabIndex = 2;
            this.closeButton.Text = "Close DropDown";
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripStatusLabel2});
            this.statusStrip1.Location = new System.Drawing.Point(0, 320);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(292, 22);
            this.statusStrip1.TabIndex = 3;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(38, 17);
            this.toolStripStatusLabel1.Text = "Ready";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(0, 17);
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(24, 30);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(74, 17);
            this.radioButton1.TabIndex = 4;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "AboveLeft";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(24, 54);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(81, 17);
            this.radioButton2.TabIndex = 5;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "AboveRight";
            this.radioButton2.UseVisualStyleBackColor = true;
            this.radioButton2.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Location = new System.Drawing.Point(24, 78);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(72, 17);
            this.radioButton3.TabIndex = 6;
            this.radioButton3.TabStop = true;
            this.radioButton3.Text = "BelowLeft";
            this.radioButton3.UseVisualStyleBackColor = true;
            this.radioButton3.CheckedChanged += new System.EventHandler(this.radioButton3_CheckedChanged);
            // 
            // radioButton4
            // 
            this.radioButton4.AutoSize = true;
            this.radioButton4.Location = new System.Drawing.Point(24, 102);
            this.radioButton4.Name = "radioButton4";
            this.radioButton4.Size = new System.Drawing.Size(79, 17);
            this.radioButton4.TabIndex = 7;
            this.radioButton4.TabStop = true;
            this.radioButton4.Text = "BelowRight";
            this.radioButton4.UseVisualStyleBackColor = true;
            this.radioButton4.CheckedChanged += new System.EventHandler(this.radioButton4_CheckedChanged);
            // 
            // radioButton5
            // 
            this.radioButton5.AutoSize = true;
            this.radioButton5.Location = new System.Drawing.Point(24, 126);
            this.radioButton5.Name = "radioButton5";
            this.radioButton5.Size = new System.Drawing.Size(59, 17);
            this.radioButton5.TabIndex = 8;
            this.radioButton5.TabStop = true;
            this.radioButton5.Text = "Default";
            this.radioButton5.UseVisualStyleBackColor = true;
            this.radioButton5.CheckedChanged += new System.EventHandler(this.radioButton5_CheckedChanged);
            // 
            // radioButton6
            // 
            this.radioButton6.AutoSize = true;
            this.radioButton6.Location = new System.Drawing.Point(24, 150);
            this.radioButton6.Name = "radioButton6";
            this.radioButton6.Size = new System.Drawing.Size(43, 17);
            this.radioButton6.TabIndex = 9;
            this.radioButton6.TabStop = true;
            this.radioButton6.Text = "Left";
            this.radioButton6.UseVisualStyleBackColor = true;
            this.radioButton6.CheckedChanged += new System.EventHandler(this.radioButton6_CheckedChanged);
            // 
            // radioButton7
            // 
            this.radioButton7.AutoSize = true;
            this.radioButton7.Location = new System.Drawing.Point(24, 174);
            this.radioButton7.Name = "radioButton7";
            this.radioButton7.Size = new System.Drawing.Size(50, 17);
            this.radioButton7.TabIndex = 10;
            this.radioButton7.TabStop = true;
            this.radioButton7.Text = "Right";
            this.radioButton7.UseVisualStyleBackColor = true;
            this.radioButton7.CheckedChanged += new System.EventHandler(this.radioButton7_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioButton7);
            this.groupBox1.Controls.Add(this.radioButton6);
            this.groupBox1.Controls.Add(this.radioButton5);
            this.groupBox1.Controls.Add(this.radioButton4);
            this.groupBox1.Controls.Add(this.radioButton3);
            this.groupBox1.Controls.Add(this.radioButton2);
            this.groupBox1.Controls.Add(this.radioButton1);
            this.groupBox1.Location = new System.Drawing.Point(149, 93);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(131, 212);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "DropDown Direction";
            // 
            // showButton
            // 
            this.showButton.Location = new System.Drawing.Point(12, 172);
            this.showButton.Name = "showButton";
            this.showButton.Size = new System.Drawing.Size(95, 23);
            this.showButton.TabIndex = 12;
            this.showButton.Text = "Show";
            this.showButton.UseVisualStyleBackColor = true;
            this.showButton.Click += new System.EventHandler(this.showButton_Click);
            // 
            // showAtPointButton
            // 
            this.showAtPointButton.Location = new System.Drawing.Point(12, 201);
            this.showAtPointButton.Name = "showAtPointButton";
            this.showAtPointButton.Size = new System.Drawing.Size(95, 23);
            this.showAtPointButton.TabIndex = 13;
            this.showAtPointButton.Text = "Show Relative";
            this.showAtPointButton.UseVisualStyleBackColor = true;
            this.showAtPointButton.Click += new System.EventHandler(this.showAtPointButton_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.item1ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.contextMenuStrip1.ShowCheckMargin = true;
            this.contextMenuStrip1.ShowImageMargin = false;
            this.contextMenuStrip1.Size = new System.Drawing.Size(114, 26);
            this.contextMenuStrip1.Closed += new System.Windows.Forms.ToolStripDropDownClosedEventHandler(this.contextMenuStrip_Closed);
            this.contextMenuStrip1.Closing += new System.Windows.Forms.ToolStripDropDownClosingEventHandler(this.contextMenuStrip_Closing);
            // 
            // item1ToolStripMenuItem
            // 
            this.item1ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.subItem1ToolStripMenuItem,
            this.subItem2ToolStripMenuItem,
            this.doneToolStripMenuItem});
            this.item1ToolStripMenuItem.Name = "item1ToolStripMenuItem";
            this.item1ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.item1ToolStripMenuItem.Text = "Item1";
            // 
            // subItem1ToolStripMenuItem
            // 
            this.subItem1ToolStripMenuItem.Name = "subItem1ToolStripMenuItem";
            this.subItem1ToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.subItem1ToolStripMenuItem.Text = "Check This Item";
            this.subItem1ToolStripMenuItem.Click += new System.EventHandler(this.subItemToolStripMenuItem_Click);
            // 
            // subItem2ToolStripMenuItem
            // 
            this.subItem2ToolStripMenuItem.Name = "subItem2ToolStripMenuItem";
            this.subItem2ToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.subItem2ToolStripMenuItem.Text = "Check This Item";
            this.subItem2ToolStripMenuItem.Click += new System.EventHandler(this.subItemToolStripMenuItem_Click);
            // 
            // doneToolStripMenuItem
            // 
            this.doneToolStripMenuItem.Enabled = false;
            this.doneToolStripMenuItem.Name = "doneToolStripMenuItem";
            this.doneToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.doneToolStripMenuItem.Text = "Done";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(66, 35);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(150, 23);
            this.button1.TabIndex = 15;
            this.button1.Text = "Button with DropDown";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.button1_MouseUp);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(12, 231);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(95, 23);
            this.button2.TabIndex = 16;
            this.button2.Text = "Show At Point";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.showAtPointButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 342);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.showAtPointButton);
            this.Controls.Add(this.showButton);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.closeButton);
            this.Controls.Add(this.autoCloseCheckBox);
            this.Name = "Form1";
            this.Text = "Form1";
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
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
            Application.Run(new Form1());
        }
    }
}
// </snippet1>