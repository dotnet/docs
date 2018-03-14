//<SNIPPET1>
using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace TestSaveFileDialog
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            button1.Click += new EventHandler(button1_Click);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = "Data text files|.data.txt";
            saveFileDialog1.SupportMultiDottedExtensions = true;
            saveFileDialog1.FileOk += new CancelEventHandler(saveFileDialog1_FileOk);
            saveFileDialog1.ShowDialog();
        }

        void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            try
            {
                Stream s = saveFileDialog1.OpenFile();
                StreamWriter sw = new StreamWriter(s, Encoding.Unicode);
                sw.WriteLine("Hello, world!");
                sw.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: Could not write file. Please try again later. Error message: " + ex.Message, "Error Writing File", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); 
            }
        }
    }
}
//</SNIPPET1>