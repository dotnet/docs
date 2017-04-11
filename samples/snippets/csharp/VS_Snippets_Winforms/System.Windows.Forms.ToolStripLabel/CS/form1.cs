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
    private ToolStripLabel toolStripLabel1;
    private ToolStrip toolStrip1;

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
        this.toolStrip1 = new System.Windows.Forms.ToolStrip();
        this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
        this.toolStrip1.SuspendLayout();
        this.SuspendLayout();
        // 
        // toolStrip1
        // 
        this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1});
        this.toolStrip1.Location = new System.Drawing.Point(0, 0);
        this.toolStrip1.Name = "toolStrip1";
        this.toolStrip1.Size = new System.Drawing.Size(292, 25);
        this.toolStrip1.TabIndex = 0;
        this.toolStrip1.Text = "toolStrip1";
        // 
        // toolStripLabel1
        // 
        this.toolStripLabel1.IsLink = true;
        this.toolStripLabel1.LinkBehavior = System.Windows.Forms.LinkBehavior.AlwaysUnderline;
        this.toolStripLabel1.Name = "toolStripLabel1";
        this.toolStripLabel1.Size = new System.Drawing.Size(71, 22);
        this.toolStripLabel1.Tag = "http://search.microsoft.com/search/search.aspx?";
        this.toolStripLabel1.Text = "Search MSDN";
        this.toolStripLabel1.Click += new System.EventHandler(this.toolStripLabel1_Click);
        // 
        // Form1
        // 
        this.ClientSize = new System.Drawing.Size(292, 273);
        this.Controls.Add(this.toolStrip1);
        this.Name = "Form1";
        this.toolStrip1.ResumeLayout(false);
        this.toolStrip1.PerformLayout();
        this.ResumeLayout(false);
        this.PerformLayout();

    }

    private void toolStripLabel1_Click(object sender, EventArgs e)
    {
        ToolStripLabel toolStripLabel1 = (ToolStripLabel)sender;

        // Start Internet Explorer and navigate to the URL in the
        // tag property.
        System.Diagnostics.Process.Start("IEXPLORE.EXE", toolStripLabel1.Tag.ToString());

        // Set the LinkVisited property to true to change the color.
        toolStripLabel1.LinkVisited = true;
    }
}
//</Snippet1>