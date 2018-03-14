using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // <snippet1>
        private void Form1_Click(object sender, EventArgs e)
        {
            Control ctl;
            ctl = (Control)sender;
            ctl.SelectNextControl(ActiveControl, true, true, true, true);
        }
        // </snippet1>

        // <snippet2>
        private void button1_Click(object sender, EventArgs e)
        {
            Control p;
            p = ((Button) sender).Parent;
            p.SelectNextControl(ActiveControl, true, true, true, true);
        }
        // </snippet2>
    }
}
