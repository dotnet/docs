using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace VbPowerPacksLineScaleCS
{
    public partial class LineScale : Form
    {
        public LineScale()
        {
            InitializeComponent();
        }

        // <Snippet1>
        private void LineScale_Load(System.Object sender, System.EventArgs e)
        {
            lineShape1.X1 = 0;
            lineShape1.Y1 = 0;
            lineShape1.X2 = 40;
            lineShape1.Y2 = 40;
        }
        private void Button1_Click(System.Object sender, System.EventArgs e)
        {
            ScaleMe(2, 2.5f);
        }
        private void ScaleMe(float x, float y)
        {
            SizeF newsize = new SizeF( x, y);
            lineShape1.Scale(newsize);
        }
        // </Snippet1>
    }
}
