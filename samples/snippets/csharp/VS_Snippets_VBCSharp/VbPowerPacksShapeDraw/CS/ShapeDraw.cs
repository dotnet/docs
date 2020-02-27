using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace VbPowerPacksShapeDrawCS
{
    public partial class ShapeDraw : Form
    {
        public ShapeDraw()
        {
            InitializeComponent();
        }

        private void ShapeDraw_Load(object sender, EventArgs e)
        {
            // <Snippet1>
            System.Drawing.Bitmap pic = new System.Drawing.Bitmap(this.pictureBox1.Image, 
                pictureBox1.Width, pictureBox1.Height);
            System.Drawing.Rectangle rect = new System.Drawing.Rectangle(lineShape1.X1, 
                lineShape1.Y1, lineShape1.X2 - lineShape1.X1, lineShape1.Y2 - lineShape1.Y1);
            lineShape1.DrawToBitmap(pic, rect);
            pictureBox2.Image = pic;
            // </Snippet1>
        }
    }
}
