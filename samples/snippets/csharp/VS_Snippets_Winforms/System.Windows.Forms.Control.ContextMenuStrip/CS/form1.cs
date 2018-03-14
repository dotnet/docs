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
    private ContextMenuStrip contextMenuStrip1;
    private ToolStripMenuItem toolStripMenuItem1;
    private ToolStripMenuItem toolStripMenuItem2;
    private ToolStripMenuItem toolStripMenuItem3;
    private IContainer components;

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
        this.components = new System.ComponentModel.Container();
        this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
        this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
        this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
        this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
        this.contextMenuStrip1.SuspendLayout();
        this.SuspendLayout();
        // 
        // contextMenuStrip1
        // 
        this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.toolStripMenuItem2,
            this.toolStripMenuItem3});
        this.contextMenuStrip1.Name = "contextMenuStrip1";
        this.contextMenuStrip1.Size = new System.Drawing.Size(180, 70);
        // 
        // toolStripMenuItem1
        // 
        this.toolStripMenuItem1.Name = "toolStripMenuItem1";
        this.toolStripMenuItem1.Size = new System.Drawing.Size(179, 22);
        this.toolStripMenuItem1.Text = "toolStripMenuItem1";
        // 
        // toolStripMenuItem2
        // 
        this.toolStripMenuItem2.Name = "toolStripMenuItem2";
        this.toolStripMenuItem2.Size = new System.Drawing.Size(179, 22);
        this.toolStripMenuItem2.Text = "toolStripMenuItem2";
        // 
        // toolStripMenuItem3
        // 
        this.toolStripMenuItem3.Name = "toolStripMenuItem3";
        this.toolStripMenuItem3.Size = new System.Drawing.Size(179, 22);
        this.toolStripMenuItem3.Text = "toolStripMenuItem3";
        // 
        // Form1
        // 
        this.ClientSize = new System.Drawing.Size(292, 273);
        this.ContextMenuStrip = this.contextMenuStrip1;
        this.Name = "Form1";
        this.contextMenuStrip1.ResumeLayout(false);
        this.ResumeLayout(false);

    }
}
//</Snippet1>