using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace TestMouseWheel
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.MouseWheel += new MouseEventHandler(Form1_MouseWheel);
        }

        void Form1_MouseWheel(object sender, MouseEventArgs e)
        {
            HandledMouseEventArgs me = (HandledMouseEventArgs)e;
            me.Handled = true;
        }
    }
}