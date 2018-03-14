
//<snippet1>
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace FormWithButton
{
    public class Form1 : Form
    {
        //<snippet2>
        public Button button1;
        public Form1()
        {
            button1 = new Button();
            button1.Size = new Size(40, 40);
            button1.Location = new Point(30, 30);
            button1.Text = "Click me";
            this.Controls.Add(button1);
            //<snippet4>
            button1.Click += new EventHandler(button1_Click);
            //</snippet4>
        }
        //</snippet2>
        //<snippet3>
        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Hello World");
        }
        //</snippet3>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.Run(new Form1());
        }
    }
}
//</snippet1>