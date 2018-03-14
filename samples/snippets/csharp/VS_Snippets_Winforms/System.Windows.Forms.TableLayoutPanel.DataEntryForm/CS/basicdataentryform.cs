// <snippet1>
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

// This form demonstrates how to build a form layout that adjusts well
// when the user resizes the form. It also demonstrates a layout that 
// responds well to localization.
class BasicDataEntryForm : System.Windows.Forms.Form
{
    public BasicDataEntryForm()
    {
        InitializeComponent();
    }
    
    private System.ComponentModel.IContainer components = null;

    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }


    public override string ToString()
    {
        return "Basic Data Entry Form";
    }

    private void okBtn_Click(object sender, EventArgs e)
    {
        this.Close();
    }

    private void cancelBtn_Click(object sender, EventArgs e)
    {
        this.Close();
    }



    private void InitializeComponent()
    {
        this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
        this.label1 = new System.Windows.Forms.Label();
        this.label2 = new System.Windows.Forms.Label();
        this.label3 = new System.Windows.Forms.Label();
        this.label4 = new System.Windows.Forms.Label();
        this.label5 = new System.Windows.Forms.Label();
        this.label6 = new System.Windows.Forms.Label();
        this.label9 = new System.Windows.Forms.Label();
        this.textBox2 = new System.Windows.Forms.TextBox();
        this.textBox3 = new System.Windows.Forms.TextBox();
        this.textBox4 = new System.Windows.Forms.TextBox();
        this.textBox5 = new System.Windows.Forms.TextBox();
        this.maskedTextBox1 = new System.Windows.Forms.MaskedTextBox();
        this.maskedTextBox2 = new System.Windows.Forms.MaskedTextBox();
        this.comboBox1 = new System.Windows.Forms.ComboBox();
        this.textBox1 = new System.Windows.Forms.TextBox();
        this.label7 = new System.Windows.Forms.Label();
        this.label8 = new System.Windows.Forms.Label();
        this.richTextBox1 = new System.Windows.Forms.RichTextBox();
        this.cancelBtn = new System.Windows.Forms.Button();
        this.okBtn = new System.Windows.Forms.Button();
        this.tableLayoutPanel1.SuspendLayout();
        this.SuspendLayout();
// 
// tableLayoutPanel1
// 
        this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                    | System.Windows.Forms.AnchorStyles.Left)
                    | System.Windows.Forms.AnchorStyles.Right)));
        this.tableLayoutPanel1.ColumnCount = 4;
        this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
        this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
        this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
        this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
        this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
        this.tableLayoutPanel1.Controls.Add(this.label2, 2, 0);
        this.tableLayoutPanel1.Controls.Add(this.label3, 0, 1);
        this.tableLayoutPanel1.Controls.Add(this.label4, 0, 2);
        this.tableLayoutPanel1.Controls.Add(this.label5, 0, 3);
        this.tableLayoutPanel1.Controls.Add(this.label6, 2, 3);
        this.tableLayoutPanel1.Controls.Add(this.label9, 2, 4);
        this.tableLayoutPanel1.Controls.Add(this.textBox2, 1, 1);
        this.tableLayoutPanel1.Controls.Add(this.textBox3, 1, 2);
        this.tableLayoutPanel1.Controls.Add(this.textBox4, 1, 3);
        this.tableLayoutPanel1.Controls.Add(this.textBox5, 3, 0);
        this.tableLayoutPanel1.Controls.Add(this.maskedTextBox1, 1, 4);
        this.tableLayoutPanel1.Controls.Add(this.maskedTextBox2, 3, 4);
        this.tableLayoutPanel1.Controls.Add(this.comboBox1, 3, 3);
        this.tableLayoutPanel1.Controls.Add(this.textBox1, 1, 0);
        this.tableLayoutPanel1.Controls.Add(this.label7, 0, 5);
        this.tableLayoutPanel1.Controls.Add(this.label8, 0, 4);
        this.tableLayoutPanel1.Controls.Add(this.richTextBox1, 1, 5);
        this.tableLayoutPanel1.Location = new System.Drawing.Point(13, 13);
        this.tableLayoutPanel1.Name = "tableLayoutPanel1";
        this.tableLayoutPanel1.RowCount = 6;
        this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
        this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
        this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
        this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
        this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
        this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 80F));
        this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
        this.tableLayoutPanel1.Size = new System.Drawing.Size(623, 286);
        this.tableLayoutPanel1.TabIndex = 0;
// 
// label1
// 
        this.label1.Anchor = System.Windows.Forms.AnchorStyles.Right;
        this.label1.AutoSize = true;
        this.label1.Location = new System.Drawing.Point(3, 7);
        this.label1.Name = "label1";
        this.label1.Size = new System.Drawing.Size(59, 14);
        this.label1.TabIndex = 20;
        this.label1.Text = "First Name";
// 
// label2
// 
        this.label2.Anchor = System.Windows.Forms.AnchorStyles.Right;
        this.label2.AutoSize = true;
        this.label2.Location = new System.Drawing.Point(323, 7);
        this.label2.Name = "label2";
        this.label2.Size = new System.Drawing.Size(59, 14);
        this.label2.TabIndex = 21;
        this.label2.Text = "Last Name";
// 
// label3
// 
        this.label3.Anchor = System.Windows.Forms.AnchorStyles.Right;
        this.label3.AutoSize = true;
        this.label3.Location = new System.Drawing.Point(10, 35);
        this.label3.Name = "label3";
        this.label3.Size = new System.Drawing.Size(52, 14);
        this.label3.TabIndex = 22;
        this.label3.Text = "Address1";
// 
// label4
// 
        this.label4.Anchor = System.Windows.Forms.AnchorStyles.Right;
        this.label4.AutoSize = true;
        this.label4.Location = new System.Drawing.Point(7, 63);
        this.label4.Name = "label4";
        this.label4.Size = new System.Drawing.Size(55, 14);
        this.label4.TabIndex = 23;
        this.label4.Text = "Address 2";
// 
// label5
// 
        this.label5.Anchor = System.Windows.Forms.AnchorStyles.Right;
        this.label5.AutoSize = true;
        this.label5.Location = new System.Drawing.Point(38, 91);
        this.label5.Name = "label5";
        this.label5.Size = new System.Drawing.Size(24, 14);
        this.label5.TabIndex = 24;
        this.label5.Text = "City";
// 
// label6
// 
        this.label6.Anchor = System.Windows.Forms.AnchorStyles.Right;
        this.label6.AutoSize = true;
        this.label6.Location = new System.Drawing.Point(351, 91);
        this.label6.Name = "label6";
        this.label6.Size = new System.Drawing.Size(31, 14);
        this.label6.TabIndex = 25;
        this.label6.Text = "State";
// 
// label9
// 
        this.label9.Anchor = System.Windows.Forms.AnchorStyles.Right;
        this.label9.AutoSize = true;
        this.label9.Location = new System.Drawing.Point(326, 119);
        this.label9.Name = "label9";
        this.label9.Size = new System.Drawing.Size(56, 14);
        this.label9.TabIndex = 33;
        this.label9.Text = "Phone (H)";
// 
// textBox2
// 
        this.textBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
        this.tableLayoutPanel1.SetColumnSpan(this.textBox2, 3);
        this.textBox2.Location = new System.Drawing.Point(68, 32);
        this.textBox2.Name = "textBox2";
        this.textBox2.Size = new System.Drawing.Size(552, 20);
        this.textBox2.TabIndex = 2;
// 
// textBox3
// 
        this.textBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
        this.tableLayoutPanel1.SetColumnSpan(this.textBox3, 3);
        this.textBox3.Location = new System.Drawing.Point(68, 60);
        this.textBox3.Name = "textBox3";
        this.textBox3.Size = new System.Drawing.Size(552, 20);
        this.textBox3.TabIndex = 3;
// 
// textBox4
// 
        this.textBox4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
        this.textBox4.Location = new System.Drawing.Point(68, 88);
        this.textBox4.Name = "textBox4";
        this.textBox4.Size = new System.Drawing.Size(249, 20);
        this.textBox4.TabIndex = 4;
// 
// textBox5
// 
        this.textBox5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
        this.textBox5.Location = new System.Drawing.Point(388, 4);
        this.textBox5.Name = "textBox5";
        this.textBox5.Size = new System.Drawing.Size(232, 20);
        this.textBox5.TabIndex = 1;
// 
// maskedTextBox1
// 
        this.maskedTextBox1.Anchor = System.Windows.Forms.AnchorStyles.Left;
        this.maskedTextBox1.Location = new System.Drawing.Point(68, 116);
        this.maskedTextBox1.Mask = "(999)000-0000";
        this.maskedTextBox1.Name = "maskedTextBox1";
        this.maskedTextBox1.TabIndex = 6;
// 
// maskedTextBox2
// 
        this.maskedTextBox2.Anchor = System.Windows.Forms.AnchorStyles.Left;
        this.maskedTextBox2.Location = new System.Drawing.Point(388, 116);
        this.maskedTextBox2.Mask = "(999)000-0000";
        this.maskedTextBox2.Name = "maskedTextBox2";
        this.maskedTextBox2.TabIndex = 7;
// 
// comboBox1
// 
        this.comboBox1.Anchor = System.Windows.Forms.AnchorStyles.Left;
        this.comboBox1.FormattingEnabled = true;
        this.comboBox1.Items.AddRange(new object[] {
            "AK - Alaska",
            "WA - Washington"});
        this.comboBox1.Location = new System.Drawing.Point(388, 87);
        this.comboBox1.Name = "comboBox1";
        this.comboBox1.Size = new System.Drawing.Size(100, 21);
        this.comboBox1.TabIndex = 5;
// 
// textBox1
// 
        this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
        this.textBox1.Location = new System.Drawing.Point(68, 4);
        this.textBox1.Name = "textBox1";
        this.textBox1.Size = new System.Drawing.Size(249, 20);
        this.textBox1.TabIndex = 0;
// 
// label7
// 
        this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
        this.label7.AutoSize = true;
        this.label7.Location = new System.Drawing.Point(28, 143);
        this.label7.Name = "label7";
        this.label7.Size = new System.Drawing.Size(34, 14);
        this.label7.TabIndex = 26;
        this.label7.Text = "Notes";
// 
// label8
// 
        this.label8.Anchor = System.Windows.Forms.AnchorStyles.Right;
        this.label8.AutoSize = true;
        this.label8.Location = new System.Drawing.Point(4, 119);
        this.label8.Name = "label8";
        this.label8.Size = new System.Drawing.Size(58, 14);
        this.label8.TabIndex = 32;
        this.label8.Text = "Phone (W)";
// 
// richTextBox1
// 
        this.tableLayoutPanel1.SetColumnSpan(this.richTextBox1, 3);
        this.richTextBox1.Dock = System.Windows.Forms.DockStyle.Fill;
        this.richTextBox1.Location = new System.Drawing.Point(68, 143);
        this.richTextBox1.Name = "richTextBox1";
        this.richTextBox1.Size = new System.Drawing.Size(552, 140);
        this.richTextBox1.TabIndex = 8;
        this.richTextBox1.Text = "";
// 
// cancelBtn
// 
        this.cancelBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
        this.cancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        this.cancelBtn.Location = new System.Drawing.Point(558, 306);
        this.cancelBtn.Name = "cancelBtn";
        this.cancelBtn.TabIndex = 1;
        this.cancelBtn.Text = "Cancel";
        this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
// 
// okBtn
// 
        this.okBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
        this.okBtn.DialogResult = System.Windows.Forms.DialogResult.OK;
        this.okBtn.Location = new System.Drawing.Point(476, 306);
        this.okBtn.Name = "okBtn";
        this.okBtn.TabIndex = 0;
        this.okBtn.Text = "OK";
        this.okBtn.Click += new System.EventHandler(this.okBtn_Click);
// 
// BasicDataEntryForm
// 
        this.ClientSize = new System.Drawing.Size(642, 338);
        this.Controls.Add(this.okBtn);
        this.Controls.Add(this.cancelBtn);
        this.Controls.Add(this.tableLayoutPanel1);
        this.Name = "BasicDataEntryForm";
        this.Padding = new System.Windows.Forms.Padding(9);
        this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
        this.Text = "Basic Data Entry";
        this.tableLayoutPanel1.ResumeLayout(false);
        this.tableLayoutPanel1.PerformLayout();
        this.ResumeLayout(false);

    }

    private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.Label label5;
    private System.Windows.Forms.Label label6;
    private System.Windows.Forms.Label label7;
    private System.Windows.Forms.Label label8;
    private System.Windows.Forms.Label label9;
    private System.Windows.Forms.Button cancelBtn;
    private System.Windows.Forms.Button okBtn;
    private System.Windows.Forms.TextBox textBox1;
    private System.Windows.Forms.TextBox textBox2;
    private System.Windows.Forms.TextBox textBox3;
    private System.Windows.Forms.TextBox textBox4;
    private System.Windows.Forms.TextBox textBox5;
    private System.Windows.Forms.MaskedTextBox maskedTextBox1;
    private System.Windows.Forms.MaskedTextBox maskedTextBox2;
    private System.Windows.Forms.ComboBox comboBox1;
    private System.Windows.Forms.RichTextBox richTextBox1;

    [STAThread]
    static void Main()
    {
        Application.EnableVisualStyles();
        Application.Run(new BasicDataEntryForm());
    }
}
// </snippet1>