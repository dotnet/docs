using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PictureViewer

{
    public partial class Form1 : Form

    {
        public Form1()

        {
            InitializeComponent();
        }

   // <snippet1>
    private void showButton_Click(object sender, EventArgs e)
    {
        if (openFileDialog1.ShowDialog() == DialogResult.OK)
        {
            pictureBox1.Load(openFileDialog1.FileName);  
        }
    }
    // </snippet1>

    }

}
