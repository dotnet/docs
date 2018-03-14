using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SelectionStartCS
{


//<Snippet1>
public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();
        this.button1.Click += new System.EventHandler(this.ButtonClickWork);
    }

    private void ButtonClickWork(object sender, EventArgs e)
    {
        this.textBox1.Text = "Hello world!";
        this.textBox1.ReadOnly = true;

        this.textBox1.Focus();
        this.textBox1.SelectionStart = this.textBox1.SelectionStart + 1;
        this.textBox1.SelectionLength = 1;
    }
}
//</Snippet1>


}