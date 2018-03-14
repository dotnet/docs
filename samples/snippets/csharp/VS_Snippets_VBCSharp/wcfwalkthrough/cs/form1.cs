using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        // <Snippet3>
        private void button1_Click(System.Object sender, System.EventArgs e)
        {
            ServiceReference1.Service1Client client = new
                ServiceReference1.Service1Client();
            string returnString;

            returnString = client.GetData(textBox1.Text);
            label1.Text = returnString;
        }
        // </Snippet3>
    }
}
