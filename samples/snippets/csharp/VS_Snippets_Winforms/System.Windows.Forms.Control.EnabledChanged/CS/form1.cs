//<Snippet1>
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

public class Form1 : Form
{
    private RadioButton radioButton1;
    private RadioButton radioButton2;

    public Form1()
    {
        InitializeComponent();
    }
    [STAThread]
    static void Main()
    {
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
        Application.Run(new Form1());
    }

    private void InitializeComponent()
    {
        this.radioButton1 = new System.Windows.Forms.RadioButton();
        this.radioButton2 = new System.Windows.Forms.RadioButton();
        this.SuspendLayout();
        // 
        // radioButton1
        // 
        this.radioButton1.AutoSize = true;
        this.radioButton1.Location = new System.Drawing.Point(0, 0);
        this.radioButton1.Name = "radioButton1";
        this.radioButton1.Size = new System.Drawing.Size(62, 17);
        this.radioButton1.TabIndex = 0;
        this.radioButton1.TabStop = true;
        this.radioButton1.Text = "Button1";
        this.radioButton1.UseVisualStyleBackColor = true;
        this.radioButton1.EnabledChanged += new System.EventHandler(this.radioButton1_EnabledChanged);
        // 
        // radioButton2
        // 
        this.radioButton2.AutoSize = true;
        this.radioButton2.Location = new System.Drawing.Point(0, 39);
        this.radioButton2.Name = "radioButton2";
        this.radioButton2.Size = new System.Drawing.Size(100, 17);
        this.radioButton2.TabIndex = 1;
        this.radioButton2.TabStop = true;
        this.radioButton2.Text = "Disable Button1";
        this.radioButton2.UseVisualStyleBackColor = true;
        this.radioButton2.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
        // 
        // Form1
        // 
        this.ClientSize = new System.Drawing.Size(292, 273);
        this.Controls.Add(this.radioButton2);
        this.Controls.Add(this.radioButton1);
        this.Name = "Form1";
        this.ResumeLayout(false);
        this.PerformLayout();

    }

    private void radioButton2_CheckedChanged(object sender, EventArgs e)
    {
        radioButton1.Enabled = false;
    }

    private void radioButton1_EnabledChanged(object sender, EventArgs e)
    {
        MessageBox.Show("This button has been disabled.");
    }
}
//</Snippet1>