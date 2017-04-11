//<snippet1>
using System;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MouseRollBackSingleClick
{
    public class Form1 : Form
    {
        private DoubleClickButton button1;
        private FormBorderStyle initialStyle;
       
        public Form1()
        {
            initialStyle = this.FormBorderStyle;
            this.ClientSize = new System.Drawing.Size(292, 266);
            button1 = new DoubleClickButton();
            button1.Location = new Point (40,40);
            button1.Click += new EventHandler(button1_Click);
            button1.AutoSize = true;
            this.AllowDrop = true;
            button1.Text = "Click or Double Click";
            button1.DoubleClick += new EventHandler(button1_DoubleClick);
            this.Controls.Add(button1);
           
        }

        
        // Handle the double click event.
        void button1_DoubleClick(object sender, EventArgs e)
        {
            // Change the border style back to the initial style.
            this.FormBorderStyle = initialStyle;
            MessageBox.Show("Rolled back single click change.");
        }

        // Handle the click event.
        void button1_Click(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.FixedToolWindow;
        }

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.Run(new Form1());
        }

        
    }
//<snippet2>
    public class DoubleClickButton : Button
    {
        public DoubleClickButton() : base()
        {
            // Set the style so a double click event occurs.
            SetStyle(ControlStyles.StandardClick | 
                ControlStyles.StandardDoubleClick, true);
        }
    }
//</snippet2>
}
//</snippet1>