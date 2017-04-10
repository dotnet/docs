using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MouseCaptureChanged
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // <snippet1>
        private void button1_MouseDown(object sender, MouseEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("button1_MouseDown");
        }

        private void button1_MouseUp(object sender, MouseEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("button1_MouseUp");
        }

        private void button1_MouseCaptureChanged(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("button1_MouseCaptureChanged");
        }
        // </snippet1>
    }
}
