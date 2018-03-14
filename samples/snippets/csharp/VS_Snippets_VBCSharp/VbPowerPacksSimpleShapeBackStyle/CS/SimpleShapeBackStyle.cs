using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.VisualBasic.PowerPacks;

namespace VbPowerPacksSimpleShapeBackStyleCS
{
    public partial class SimpleShapeBackStyle : Form
    {
        public SimpleShapeBackStyle()
        {
            InitializeComponent();
        }

        // <Snippet1>
        private void ovalShape1_Click(System.Object sender, System.EventArgs e)
        {
            // Change between transparent and opaque.
            if (ovalShape1.BackStyle == BackStyle.Transparent)
            {
                ovalShape1.BackStyle = BackStyle.Opaque;
                ovalShape1.BackColor = Color.LimeGreen;
            }
            else
            {
                ovalShape1.BackStyle = BackStyle.Transparent;
            }
        }
        // </Snippet1>
    }
}
