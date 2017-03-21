using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace KeysConverterCS
{


//<Snippet1>
public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();

        this.textBox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.KeyPressWork);
        this.textBox1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.KeyDownWork);
    }

    private void KeyDownWork(object sender, KeyEventArgs e)
    {
        MessageBox.Show(e.KeyCode.ToString(), "KeyDown");

        KeysConverter kc = new KeysConverter();
        MessageBox.Show(kc.ConvertToString(e.KeyCode), "KeyDown");
    }

    private void KeyPressWork(object sender, KeyPressEventArgs e)
    {
        MessageBox.Show(e.KeyChar.ToString(), "KeyPress");
    }
}
//</Snippet1>


}