using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.VisualBasic.PowerPacks;

namespace VbPowerPacksSimpleShapeDrawCS
{
    public partial class SimpleShapeDraw : Form
    {
        public SimpleShapeDraw()
        {
            InitializeComponent();
        }

        // <Snippet1>
        private void form1_Load(System.Object sender, System.EventArgs e)
        {
            System.Drawing.Bitmap pic = new System.Drawing.Bitmap(this.pictureBox1.Image, 
                pictureBox1.Width, pictureBox1.Height);
            System.Drawing.Rectangle rect = new System.Drawing.Rectangle();
            // Assign the client rectangle.
            rect = ovalShape1.ClientRectangle;
            // Draw the oval on the bitmap.
            ovalShape1.DrawToBitmap(pic, rect);
            pictureBox2.Image = pic;
        }
        // </Snippet1>
    }
}
