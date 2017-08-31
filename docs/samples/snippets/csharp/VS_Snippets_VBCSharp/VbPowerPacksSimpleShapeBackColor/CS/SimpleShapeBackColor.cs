using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.VisualBasic.PowerPacks;


namespace VbPowerPacksSimpleShapeBackColorCS
{
    public partial class SimpleShapeBackColor : Form
    {
        public SimpleShapeBackColor()
        {
            InitializeComponent();
        }

        // <Snippet1>
        private void ovalShape1_Click(System.Object sender, System.EventArgs e)
        {
            // Set the BackStyle and FillStyle.
            ovalShape1.BackStyle = BackStyle.Opaque;
            ovalShape1.FillStyle = FillStyle.Transparent;
            // Change the color between red and blue.
            if (ovalShape1.BackColor == Color.Red)
            {
                ovalShape1.BackColor = Color.Blue;
            }
            else
            {
                ovalShape1.BackColor = Color.Red;
            }
        }
        // </Snippet1>
    }
}
