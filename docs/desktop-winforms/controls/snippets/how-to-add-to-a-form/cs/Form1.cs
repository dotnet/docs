using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace cs
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // <CreateControl>
            Label label1 = new Label()
            {
                Text = "&First Name",
                Location = new Point(10, 10),
                TabIndex = 10
            };

            TextBox field1 = new TextBox()
            {
                Location = new Point(label1.Location.X, label1.Bounds.Bottom + Padding.Top),
                TabIndex = 11
            };

            Controls.Add(label1);
            Controls.Add(field1);
            // </CreateControl>
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
