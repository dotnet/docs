using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication2
{
    public partial class Form1 : Form
    {
        

        public Form1()
        {
            InitializeComponent();
            InitializeDialogAndButton();
        }

        private void InitializeComponent()
        {
            this.ClientSize = new System.Drawing.Size(284, 264);
        }
        //<snippet1>
        private OpenFileDialog openFileDialog1;
        private Button button1;
        
        private void InitializeDialogAndButton()
        {
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.button1 = new System.Windows.Forms.Button();
            this.button1.Location = new System.Drawing.Point(53, 37);
            this.button1.AutoSize = true;
            this.button1.Text = "Show dialog with custom places.";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            this.Controls.Add(this.button1);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Add Pictures custom place using GUID.
            openFileDialog1.CustomPlaces.Add("33E28130-4E1E-4676-835A-98395C3BC3BB");

            // Add Links custom place using GUID
            openFileDialog1.CustomPlaces.Add(
                new FileDialogCustomPlace(
                new Guid("BFB9D5E0-C6A9-404C-B2B2-AE6DB6AF4968")));

            // Add Windows custom place using file path.
            openFileDialog1.CustomPlaces.Add(@"c:\Windows");

            openFileDialog1.ShowDialog();
        }
        //</snippet1>


        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
