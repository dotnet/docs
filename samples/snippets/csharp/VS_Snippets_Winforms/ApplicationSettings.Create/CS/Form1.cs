using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace AppSettingsArchitectureProject
{
    public partial class Form1 : Form
    {
	
        public Form1()
        {
            InitializeComponent();
            this.FormClosing += new FormClosingEventHandler(Form1_FormClosing);
        }
	
	//<SNIPPET3>
	//Make sure to hook up this event handler in the constructor!
	//this.FormClosing += new FormClosingEventHandler(Form1_FormClosing);
        void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            mus.Save();
        }
	//</SNIPPET3>

        private void button1_Click(object sender, EventArgs e)
        {
            mus.BackgroundColor = Color.Black;
        }

        //<SNIPPET2>
        MyUserSettings mus;

        private void Form1_Load(object sender, EventArgs e)
        {
            mus = new MyUserSettings();
            mus.BackgroundColor = Color.AliceBlue;
            this.DataBindings.Add(new Binding("BackColor", mus, "BackgroundColor"));
        }
        //</SNIPPET2>
    }
}