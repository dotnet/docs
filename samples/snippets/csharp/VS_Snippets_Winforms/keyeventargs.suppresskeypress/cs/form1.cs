using System;
using System.Windows.Forms;

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

// <snippet1>
private void textBox1_KeyDown(object sender, KeyEventArgs e)
{
    if (e.KeyCode >= Keys.D0 && e.KeyCode <= Keys.D9 && e.Modifiers != Keys.Shift)
    {
        e.SuppressKeyPress = true;
    }
}
// </snippet1>
    }
