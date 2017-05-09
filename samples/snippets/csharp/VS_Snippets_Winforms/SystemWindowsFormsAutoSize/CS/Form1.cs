using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace AutoSizeCS
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


//<Snippet1>
private void button1_Click(object sender, EventArgs e)
{
    this.textBox1.AutoSize = true;
    this.textBox1.Text = "Hello world!";
    this.textBox1.Font = new System.Drawing.Font("Arial", 10, FontStyle.Regular);

    this.textBox2.AutoSize = false;
    this.textBox2.Text = "Hello world!";
    this.textBox2.Font = new System.Drawing.Font("Arial", 10, FontStyle.Regular);
}

private void button2_Click(object sender, EventArgs e)
{
    this.textBox1.AutoSize = true;
    this.textBox1.Text = "Goodbye world!";
    this.textBox1.Font = new System.Drawing.Font("ArialBlack", 14, FontStyle.Regular);

    this.textBox2.AutoSize = false;
    this.textBox2.Text = "Goodbye world!";
    this.textBox2.Font = new System.Drawing.Font("ArialBlack", 14, FontStyle.Regular);
}
//</Snippet1>


    }
}