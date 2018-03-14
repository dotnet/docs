using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PictureBoxSixeModeCS
{
    public class Form1 : Form
    {
        public Form1()
        { 
            this.Load += new EventHandler(Form1_Load);
            
        }
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
        void Form1_Click(object sender, EventArgs e)
        {
            throw new Exception("The method or operation is not implemented.");
        }
        //<snippet10>
        PictureBox PictureBox1 = new PictureBox();
        Button Button1 = new Button();

        private void InitializePictureBoxAndButton()
        {

            this.Controls.Add(PictureBox1);
            this.Controls.Add(Button1);
            Button1.Location = new Point(175, 20);
            Button1.Text = "Stretch";
            Button1.Click += new EventHandler(Button1_Click);

            // Set the size of the PictureBox control.
            this.PictureBox1.Size = new System.Drawing.Size(140, 140);

            //Set the SizeMode to center the image.
            this.PictureBox1.SizeMode = PictureBoxSizeMode.CenterImage;

            // Set the border style to a three-dimensional border.
            this.PictureBox1.BorderStyle = BorderStyle.Fixed3D;

            // Set the image property.
            this.PictureBox1.Image = new Bitmap(typeof(Button), "Button.bmp");
        }

        private void Button1_Click(System.Object sender, System.EventArgs e)
        {
            // Set the SizeMode property to the StretchImage value.  This
            // will enlarge the image as needed to fit into
            // the PictureBox.
            PictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
        }
        //</snippet10>


        private void Form1_Load(System.Object sender, System.EventArgs e)
        {
            InitializePictureBoxAndButton();
        }
    }
}



