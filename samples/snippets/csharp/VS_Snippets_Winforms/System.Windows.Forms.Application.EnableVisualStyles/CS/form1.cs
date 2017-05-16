//<Snippet1>
using System;
using System.Drawing;
using System.Windows.Forms;

namespace VStyles
{
    public class Form1 : System.Windows.Forms.Form
    {

        private System.Windows.Forms.Button button1;
        
        [STAThread]
        static void Main() 
        {
            Application.EnableVisualStyles();
            Application.Run(new Form1());
        }

        public Form1()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.button1.Location = new System.Drawing.Point(24, 16);
            this.button1.Size = new System.Drawing.Size(120, 100);
            this.button1.FlatStyle = FlatStyle.System;
            this.button1.Text = "I am themed.";

            // Sets up how the form should be displayed and adds the controls to the form.
            this.ClientSize = new System.Drawing.Size(300, 286);
            this.Controls.Add(this.button1);

            this.Text = "Application.EnableVisualStyles Example";

        }
    }
}
//</Snippet1>