using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace BitmapAtRuntime
{
    public class Form1 : Form
    {
        public Form1()
        {
            this.Paint += new PaintEventHandler(Form1_Paint);
        }

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }

        void Form1_Paint(object sender, PaintEventArgs e)
        {
            CreateBitmapAtRuntime();
        }

            //<snippet1>
        PictureBox pictureBox1 = new PictureBox();
        public void CreateBitmapAtRuntime()
        {
            pictureBox1.Size = new Size(210, 110);
            this.Controls.Add(pictureBox1);

            Bitmap flag = new Bitmap(200, 100);
            Graphics flagGraphics = Graphics.FromImage(flag);
            int red = 0;
            int white = 11;
            while (white <= 100) {
                flagGraphics.FillRectangle(Brushes.Red, 0, red, 200,10);
                flagGraphics.FillRectangle(Brushes.White, 0, white, 200, 10);
                red += 20;
                white += 20;
            }
            pictureBox1.Image = flag;
         
        }
   //</snippet1>
    }
}