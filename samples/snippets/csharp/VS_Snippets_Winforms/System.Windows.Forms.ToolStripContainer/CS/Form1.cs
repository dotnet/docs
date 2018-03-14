// <Snippet1>
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;


public class Form1 : Form
{
    private ToolStripContainer tsc;
    private RichTextBox rtb;

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
        this.tsc = new System.Windows.Forms.ToolStripContainer();
        this.rtb = new System.Windows.Forms.RichTextBox();
        this.tsc.ContentPanel.Controls.Add(this.rtb);
        this.Controls.Add(this.tsc);

    }
}
// </Snippet1>
