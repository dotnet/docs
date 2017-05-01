#region Using directives

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Imaging;

#endregion

namespace RotateColors
{
    public class Form1 : Form
    {
        public Form1()
        {
            this.Paint +=new PaintEventHandler(Form1_Paint);
        }


        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.Run(new Form1());
        }

        void Form1_Paint(object sender, PaintEventArgs e)
        {
            RotateColors(e);
        }
//<snippet1>
        private void RotateColors(PaintEventArgs e)
        {
            Bitmap image = new Bitmap("RotationInput.bmp");
            ImageAttributes imageAttributes = new ImageAttributes();
            int width = image.Width;
            int height = image.Height;
            float degrees = 60f;
            double r = degrees * System.Math.PI / 180; // degrees to radians

            float[][] colorMatrixElements = { 
                new float[] {(float)System.Math.Cos(r),  (float)System.Math.Sin(r),  0,  0, 0},
                new float[] {(float)-System.Math.Sin(r),  (float)-System.Math.Cos(r),  0,  0, 0},
                new float[] {0,  0,  2,  0, 0},
                new float[] {0,  0,  0,  1, 0},
                new float[] {0, 0, 0, 0, 1}};

            ColorMatrix colorMatrix = new ColorMatrix(colorMatrixElements);

            imageAttributes.SetColorMatrix(
               colorMatrix,
               ColorMatrixFlag.Default,
               ColorAdjustType.Bitmap);

            e.Graphics.DrawImage(image, 10, 10, width, height);

            e.Graphics.DrawImage(
               image,
               new Rectangle(150, 10, width, height),  // destination rectangle 
                0, 0,        // upper-left corner of source rectangle 
                width,       // width of source rectangle
                height,      // height of source rectangle
                GraphicsUnit.Pixel,
               imageAttributes);

        }
//</snippet1>

      
    }
}