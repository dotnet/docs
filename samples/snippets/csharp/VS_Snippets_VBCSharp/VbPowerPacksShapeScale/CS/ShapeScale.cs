using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace VbPowerPacksShapeScaleCS
{
    public partial class ShapeScale : Form
    {
        public ShapeScale()
        {
            InitializeComponent();
        }

        // <Snippet1>
        private void ovalShape1_Click(System.Object sender, System.EventArgs e)
        {
            bool state = true;
            if (state == false)
            {
                ovalShape1.Scale(new SizeF(2, 3));
                state = true;
            }
            else
            {
                ovalShape1.Scale(new SizeF(0.5f, 0.333f));
                state = false;
            }
        }
        // </Snippet1>
    }
}
