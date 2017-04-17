using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.VisualBasic.PowerPacks;

namespace VbPowerPacksSimpleShapeFillColorCS
{
    public partial class SimpleShapeFillColor : Form
    {
        public SimpleShapeFillColor()
        {
            InitializeComponent();
        }

        // <Snippet1>
        private void ovalShape1_Click(System.Object sender, System.EventArgs e)
        {
            // Set the fill style.
            ovalShape1.FillStyle = FillStyle.Solid;
            // Set the fill color.
            ovalShape1.FillColor = Color.Red;
            // Set the gradient style.
            ovalShape1.FillGradientStyle = FillGradientStyle.Central;
            // Set the gradient color.
            ovalShape1.FillGradientColor = Color.Purple;
        }
        // </Snippet1>
    }
}
