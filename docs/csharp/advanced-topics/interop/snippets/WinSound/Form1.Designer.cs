﻿namespace WinSound;

partial class Form1
{
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        this.components = new System.ComponentModel.Container();
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(800, 450);
        this.Text = "Form1";

        //<Initialization>
        this.button1 = new System.Windows.Forms.Button();
        this.textBox1 = new System.Windows.Forms.TextBox();
        this.SuspendLayout();
        //
        // button1
        //
        this.button1.Location = new System.Drawing.Point(192, 40);
        this.button1.Name = "button1";
        this.button1.Size = new System.Drawing.Size(88, 24);
        this.button1.TabIndex = 0;
        this.button1.Text = "Browse";
        this.button1.Click += new System.EventHandler(this.button1_Click);
        //
        // textBox1
        //
        this.textBox1.Location = new System.Drawing.Point(8, 40);
        this.textBox1.Name = "textBox1";
        this.textBox1.Size = new System.Drawing.Size(168, 20);
        this.textBox1.TabIndex = 1;
        this.textBox1.Text = "File path";
        //
        // Form1
        //
        this.AutoScaleDimensions = new System.Drawing.SizeF(5, 13);
        this.ClientSize = new System.Drawing.Size(292, 266);
        this.Controls.Add(this.textBox1);
        this.Controls.Add(this.button1);
        this.Name = "Form1";
        this.Text = "Platform Invoke WinSound C#";
        this.ResumeLayout(false);
        this.PerformLayout();
        //</Initialization>

    }

    #endregion
}
