using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Deployment.Application;

namespace ClickOnce.OpenDataFile
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //<SNIPPET1>
            if (ApplicationDeployment.IsNetworkDeployed)
            {
                try
                {
                    using (StreamReader sr = new StreamReader(ApplicationDeployment.CurrentDeployment.DataDirectory + @"\CSV.txt"))
                    {
                        MessageBox.Show(sr.ReadToEnd());
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Could not read file. Error message: " + ex.Message);
                }
            }
            //</SNIPPET1>
        }
    }
}